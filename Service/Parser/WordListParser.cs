using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using Ngaq.Core.Service.Parser.Model;

using I_Iter_u8 = Ngaq.Core.Stream.I_Iter<byte>;


namespace Ngaq.Core.Service.Parser;

//靜態多態
using W = byte;
using state_t = WordParseState;

public class ParseErr : Exception{
	public ParseErr(str msg):base(msg){

	}

	public I_LineCol? LineCol{get;set;}
	public u64? Pos{get;set;}
}

public class Pos : I_LineCol{
	public Pos(){

	}
	public u64 Line {get; set;} = 0;
	public u64 Col {get; set;} = 0;

	public override str ToString(){
		return $"({Line},{Col})";
	}
}

public class Status{
	public state_t State {get; set;} = state_t.Start;
	public I_LineCol Line_col {get; set;} = new Pos();
	public u64 Pos {get;set;} = 0;

	public Stack<state_t> Stack {get; set;} = new();

	public W CurChar {get; set;} = default;

	public IList<W> Buffer {get; set;} = new List<W>();

	public IList<W> MetadataBuf {get; set;} = new List<W>();

	public WordListTxtMetadata? Metadata{get; set;}

	public IList<I_DateBlock> DateBlocks {get; set;} = new List<I_DateBlock>();

	public W headOfWordDelimiter{get;set;} = default;

}

public class Tokens{
	public const str s_metadataTag = "<metadata>";
	public const str e_metadataTag = "</metadata>";
}


public class WordListParser{
	I_Iter_u8 _GetNextByte;
	public i64 ByteSize{get;set;}//?
	public WordListParser(I_Iter_u8 getNextChar){
		_GetNextByte = getNextChar;
	}
	public Status Status {get; set;}= new Status();

	public I_LineCol LineCol{
		get{
			return Status.Line_col;
		}
	}

	public state_t E_State{
		get{
			return Status.State;
		}
		set{
			Status.State = value;
		}
	}

	//讀ʹ果ˇ存
	public IList<W> Buffer{
		get{
			return Status.Buffer;
		}
	}

	public IList<W> PreReadBuffer{get;set;} = new List<W>();
	public i32 Pos_PreRead{get;set;} = 0;

	public Encoding Encoding{get; set;} = Encoding.UTF8;

	public bool UnifiedNewLine{get; set;} = true;

	// [Obsolete]
	// public I_DateBlock getCurDateBlock(){
	// 	if(_status.dateBlocks.Count == 0){
	// 		error("No date block");
	// 		return null!;
	// 	}
	// 	return _status.dateBlocks[_status.dateBlocks.Count - 1];
	// }

	// public I_WordBlock getCurWordBlock(){
	// 	var curDateBlock = getCurDateBlock();
	// 	if(curDateBlock.words.Count == 0){
	// 		error("No word block"); return null!;
	// 	}
	// 	var curWordBlock = curDateBlock.words[curDateBlock.words.Count - 1];
	// 	return curWordBlock;
	// }

	public bool HasNext(){
		return _GetNextByte.HasNext();
	}

	protected W TryGetNextByte(){
		var ans = _GetNextByte.Next();
		// word ans;
		// if(pos_preRead < preReadBuffer.Count){
		// 	ans = preReadBuffer[pos_preRead];
		// 	pos_preRead++;
		// }else{
		// 	ans =  _getNextChar.GetNextChar();
		// }

		// if(isNil(ans)){
		// 	return ans;
		// }

		// if(unifiedNewLine){
		// 	if( eq(ans, '\r') ){
		// 		var p =  PreRead();
		// 		if( eq(p, '\n') ){
		// 			ans = '\n';
		// 			preReadBuffer.Clear();
		// 			pos_preRead = 0;
		// 			_status.pos++;
		// 		}
		// 	}
		// }

		//lineCol.col++;
		Status.Pos++;
		// if( eq(ans , '\n') ){
		// 	lineCol.line++;
		// 	lineCol.col = 0;
		// }
		Status.CurChar = ans;


		return ans;
	}

	i64 _cnt = 0;
	Stopwatch _sw = new Stopwatch();
	public W NextByte(){
		if(!HasNext()){
			Error("Unexpected EOF");
			return 1;
		}
		var c =  TryGetNextByte();
		return c;
	}



	public W NextChar(u64 pos){
		if(!HasNext()){
			Error($"From {pos} to Unexpected EOF");
		}
		var c =  TryGetNextByte();
		return c;
	}


	//編寫期多態
	public bool Eq(str s1, str s2){
		return s1 == s2;
	}

	// public bool eq(word s1, str s2){
	// 	if(s2.Length > 1){
	// 		return false;
	// 	}
	// 	return s1 == s2[0];
	// }

	public bool Eq(W s1, char s2){
		return s1 == s2;
	}

	public bool Eq(W s1, W s2){
		return s1 == s2;
	}


	/// <summary>
	/// 會清空buffer
	/// </summary>
	/// <returns></returns>
	public I_StrSegment BufferToStrSegmentEtClr(){
		var start = Status.Pos - (u64)Status.Buffer.Count;
		var text = BufToStr(Status.Buffer);
		Status.Buffer.Clear();
		return new StrSegment{
			Start = start
			,Text = text
		};
	}


	public nil ParseMetadataBuffer(IList<W> buffer){
		var txt = BufToStr(buffer);
		var obj = WordListTxtMetadata.Parse(txt);
		if(obj == null){
			Error("Invalid metadata");return Nil;
		}
		Status.Metadata = obj;
		if(obj.Delimiter == null || obj.Delimiter.Length == 0){
			Error("Invalid delimiter");return Nil;
		}
		Status.headOfWordDelimiter = (byte)obj.Delimiter[0]; //TODO
		return null!;
	}

	public IList<I_DateBlock> Parse(){
		IList<I_DateBlock> ans = new List<I_DateBlock>();
		for(var i = 0;;i++){
			switch(Status.State){
				case state_t.Start:
					Start(); // -> TopSpace
				break;
				case state_t.TopSpace:
					TopSpace(); // -> Metadata, DateBlock, End
				break;
				case state_t.Metadata:
					Metadata(); // -> TopSpace
				break;
				case state_t.DateBlock:
					var ua = ReadDateBlock(); // -> TopSpace
					ans.Add(ua);
				break;
				case state_t.End:
					return ans;
				//break;
			}
		}
		//return null!;
	}

	nil Start(){
		E_State = state_t.TopSpace;
		return null!;
	}

	nil TopSpace(){
		for(;;){
			if(!HasNext()){
				E_State = state_t.End;
				return null!;
			}
			var c =  TryGetNextByte();
			//G.logNoLn((char)(c??48));
			if(IsWhite(c)){
				continue;
			}else if( Eq(c , '<') ){
				E_State = state_t.Metadata;
				//_status.stack.Push(WordParseState.Metadata);
				break;
			}else if( Eq(c , '[') ){
				E_State = state_t.DateBlock;
				//_status.stack.Push(WordParseState.DateBlock);
				break;
			}
		}
		return null!;
	}

	public I_StrSegment ReadDate(){
		var buf = new List<W>();
		var start = Status.Pos;
		for(;;){
			var c =  NextByte();
			if( Eq(c , ']') ){
				//state = WordParseState.TopSpace;
				var ans = new StrSegment{
					Start = start
					,Text = BufToStr(buf)
				};
				return ans;
			}
			buf.Add(c);
		}
	}

	public I_DateBlock ReadDateBlock(){
		var ans = new DateBlock();
		for(;;){
			switch(E_State){
				case state_t.DateBlock: //入口
					//_status.state = WordParseState.DateBlock_date;
					ans.Date =  ReadDate();
					E_State = state_t.DateBlock_TopSpace;
				break;
				case state_t.DateBlock_TopSpace:
					DateBlock_TopSpace(); // -> Prop, WordBlocks
				break;
				case state_t.Prop:
					var prop = ReadProp();
					ans.Props.Add(prop);
					E_State = state_t.DateBlock_TopSpace;
				break;
				case state_t.WordBlocks:
					var wordBlocks = ReadWordBlocks(); // -> TopSpace
					foreach(var w in wordBlocks){ans.Words.Add(w);}
				break;
				case state_t.DateBlockEnd:
					E_State = state_t.TopSpace;
				break;
				case state_t.TopSpace:
					return ans;
				//break;
			}
		}
		//return null!;
	}

	public string BufToStr(IList<W> buf){
		var encoding = this.Encoding;
		//word 是int的別名、幫我實現這個方法。
		if(buf.Count == 0){
			return "";
		}
		//var bytes = new byte[buf.Count];
		// for (int i = 0; i < buf.Count; i++){
		// 	// 检查是否超出 byte 的范围 (0-255)
		// 	// if (buf[i] < 0 || buf[i] > 255){
		// 	// 	throw new std.ArgumentOutOfRangeException(nameof(buf), $"Word value {buf[i]} is out of range for byte.");
		// 	// }
		// 	bytes[i] = (byte)buf[i];
		// }
		//var bytes = buf.ToArray();
		return encoding.GetString(buf.ToArray());
	}

	// public str bufToStr(IList<word> buf){
	// 	var encoding = this.encoding;
	// 	//IList<byte> nonNullBuf = (IList<byte>)buf;
	// 	var nonNull
	// 	var arr = nonNullBuf.ToArray();
	// 	return encoding.GetString(arr);
	// }

	public I_StrSegment ReadLine(){
		var buf = new List<W>();
		var start = Status.Pos;
		for(;;){
			var c = NextByte();
			if( Eq(c , '\n')){
				//state = WordParseState.RestOfWordBlock;
				var ans = new StrSegment{
					Start = start
					,Text = BufToStr(buf)
				};
				return ans;
			}
			buf.Add(c);
		}
	}

	// public nil chkUnexpectedEOF(str? c){
	// 	if( isNil(c) ){
	// 		error("Unexpected EOF");
	// 		return 1;
	// 	}
	// 	return null!;
	// }

	// 不含prop之wordBlockBody
	/// @return body之I_StrSegment、非完整。
	I_StrSegment WordBlockBody(){
		//buffer.Add(_status.curChar);
		for(;;){
			var c =  NextByte();
			if( Eq(c , '[') ){
				var c2 =  NextByte();
				if( Eq(c2, '[') ){
					E_State = state_t.Prop;
					return BufferToStrSegmentEtClr();
				}else{
					Buffer.Add(c);
					Buffer.Add(c2);
				}
			}else if( Eq(c , Status.headOfWordDelimiter) ){
				E_State = state_t.HeadOfWordDelimiter;
				Status.Stack.Push(state_t.RestOfWordBlock);
				return BufferToStrSegmentEtClr();
			}else if( Eq(c , '}')){
				var c2 =  NextByte();
				if( Eq(c2 , '}') ){
					E_State = state_t.DateBlockEnd; // -> WordBlock_TopSpace -> DateBlockEnd
					return BufferToStrSegmentEtClr();
				}else{
					Buffer.Add(c);
					Buffer.Add(c2);
				}
			}else{
				Buffer.Add(c);
			}
		}


	}


/// <summary>
/// -> Prop, RestOfWordBlock
/// </summary>
/// <returns></returns>
	// public nil FirstLeftSquareBracketInWordBlockProp(){
	// 	buffer.Add(_status.curChar); // 加上 第一個 "["
	// 	for(;;){
	// 		var c =  GetNextChar();
	// 		if( eq(c , '[') ){
	// 			state=WPS.Prop;
	// 			buffer.Clear();
	// 			break;
	// 		}else{
	// 			buffer.Add(c);
	// 			state=WPS.RestOfWordBlock;
	// 			break;
	// 		}
	// 	}
	// 	return null!;
	// }


	public nil HeadOfWordDelimiter(){
		var toReturn = Status.Stack.Pop();
		return HeadOfWordDelimiter(toReturn);
	}

	public nil HeadOfWordDelimiter(state_t stateToReturn){
		Buffer.Add(Status.CurChar); // 加上 delimiter首字符
		var delimiter = Status.Metadata?.Delimiter??throw Error("_status.metadata?.Delimiter is");
		for(var i = 1;i < delimiter.Length;i++){
			var c =  NextByte();
			Buffer.Add(c);
			if( !Eq(c , delimiter[i]) ){
				//state = WordParseState.RestOfWordBlock; // not delimiter
				E_State = stateToReturn; // 回復原狀態, WordBlock_TopSpace或RestOfWordBlock或FirstLine
				return null!;
			}
		}
		E_State = state_t.WordBlockEnd;
		Buffer.Clear();
		return null!;
	}

	///read until next non-white character
	public W SkipWhite(){
		for(;;){
			var c =  NextByte();
			if(!IsWhite(c)){
				return c;
			}

		}
	}


	public nil WordBlock_TopSpace(){
		var start = Status.Pos;
		for(;;){
			var c =  NextChar(start);
			//var c =  GetNextNullableChar();
			//G.log(_status.pos,"______"+(char)c);
			if(IsWhite(c)){
				continue;
			}
			if( Eq(c, Status.headOfWordDelimiter) ){
				E_State = state_t.HeadOfWordDelimiter;
				Status.Stack.Push(state_t.WordBlock_TopSpace);
				return null!;
			}else if( Eq(c, '}')){
				var c2 =  NextByte();
				if(Eq(c2, '}')){// }} end of date block
					E_State = state_t.DateBlockEnd;
					return null!;
				}
			}
			else{
				E_State = state_t.WordBlockFirstLine;
				return null!;
			}
		}
	}

	public I_StrSegment ParseWordBlockHead(){
		Buffer.Add(Status.CurChar);
		for(;;){
			var c =  NextByte();
			if( Eq(c, '\n') ){
				E_State = state_t.RestOfWordBlock;
				return BufferToStrSegmentEtClr();
			}
			Buffer.Add(c);
		}
	}

	public IList<I_WordBlock> ReadWordBlocks(){
		var ans = new List<I_WordBlock>();
		var ua = new WordBlock();
		for(;;){
			//G.log(_status.pos, _status.line_col);
			switch(E_State){
				case state_t.WordBlocks: // 入口
					E_State = state_t.WordBlock_TopSpace;
				break;
				case state_t.WordBlock_TopSpace:
					WordBlock_TopSpace(); // -> DateBlockEnd, WordBlockFirstLine, headOfWordDelimiter
				break;
				case state_t.WordBlockFirstLine:
					var head =  ParseWordBlockHead(); // -> RestOfWordBlock
					if(head == null || head.Text.Length == 0){
						continue;
					}
					ua.Head = head;
				break;

				case state_t.RestOfWordBlock:
					//state->, HeadOfWordDelimiter, Prop, DateBlockEnd
					var bodySeg = WordBlockBody();
					ua.Body.Add(bodySeg);
				break;

				// case WPS.FirstLeftSquareBracketInWordBlockProp:
				// 	 FirstLeftSquareBracketInWordBlockProp(); // -> Prop, RestOfWordBlock
				// break;

				case state_t.Prop:
					// WordBlockProp(); // -> RestOfWordBlock
					var prop = ReadProp();
					ua.Props.Add(prop);
					E_State = state_t.RestOfWordBlock;
				break;

				case state_t.HeadOfWordDelimiter:
					// state -> state = _status.stack.Pop(), WordBlockEnd
					HeadOfWordDelimiter();
				break;

				case state_t.WordBlockEnd:
					if(ua.Head != null && ua.Head.Text.Length > 0){
						ans.Add(ua);
						ua = new WordBlock();
					}
					E_State = state_t.WordBlock_TopSpace;
				break;

				case state_t.DateBlockEnd: // 出口
					ans.Add(ua);
					return ans;
			}
		}

	}


/*
TODO 空wordBlock、及head中有不完整ʹ分隔符者
 */
	// public I_WordBlock? ReadOneWordBlock(){
	// 	I_StrSegment? head = null;
	// 	var bodySegs = new List<I_StrSegment>();
	// 	var props = new List<I_Prop>();
	// 	for(;;){
	// 		G.log(state.ToString());
	// 		switch (state){
	// 			case WPS.WordBlocks: // 入口
	// 				// var firstLine =  ReadLine(); //TODO
	// 				// head = firstLine;
	// 				// state = WordParseState.RestOfWordBlock;
	// 				state = WPS.WordBlock_TopSpace;
	// 			break;
	// 			case WPS.WordBlock_TopSpace:
	// 				 WordBlock_TopSpace(); // -> HeadOfWordDelimiter, FirstLine
	// 			break;
	// 			case WPS.WordBlockFirstLine:
	// 				head =  ParseWordBlockHead(); // -> RestOfWordBlock
	// 				if(head == null || head.text.Length == 0){
	// 					return null;//TODO 判斷純空白
	// 				}
	// 			break;
	// 			case WPS.RestOfWordBlock:
	// 				var bodySeg =  WordBlockBody();
	// 				bodySegs.Add(bodySeg);
	// 				//state->WordParseState.FirstLeftSquareBracketInWordBlockProp;
	// 			break;
	// 			case WPS.FirstLeftSquareBracketInWordBlockProp:
	// 				 FirstLeftSquareBracketInWordBlockProp(); // -> Prop, RestOfWordBlock
	// 			break;
	// 			case WPS.Prop:
	// 				// WordBlockProp(); // -> RestOfWordBlock
	// 				var prop =  ReadProp();
	// 				props.Add(prop);
	// 				state = WPS.RestOfWordBlock;
	// 			break;
	// 			case WPS.HeadOfWordDelimiter:
	// 				// state -> WordBlockEnd, RestOfWordBlock
	// 				 HeadOfWordDelimiter();
	// 			break;
	// 			case WPS.WordBlockEnd:
	// 				state = WPS.WordBlock_TopSpace;
	// 				if(head == null){
	// 					return null;
	// 				}
	// 				var ans = new WordBlock{
	// 					head = head
	// 					,body = bodySegs
	// 					,props = props
	// 				};
	// 				return ans;
	// 			//break;
	// 		}
	// 	}
	// }

	//讀完日期後 、[2024-10-19T15:51:19.877+08:00] 後面
	public nil DateBlock_TopSpace(){
		for(;;){
			var c = NextByte();
			if(IsWhite(c)){
				continue;
			}
			if( Eq(c , '[') ){
				var c2 =  NextByte();
				if(Eq(c2 , '[')){
					Status.State = state_t.Prop;
					break;
				}else{
					Error("Unexpected character");
					return Nil;
				}
			}else if( Eq(c , '{') ){
				var c2 = NextByte();
				if(Eq(c2 , '{')){
					Status.State = state_t.WordBlocks;
					break;
				}else{
					Error("Unexpected character");
					return Nil;
				}
			}
		}
		return null!;
	}


	public I_Prop ReadProp(){
		var key = ReadPropKey();
		var value = ReadPropValue();
		var ans = new Prop{
			Key = key
			,Value = value
		};
		return ans;
	}

	public I_StrSegment ReadPropValue(){
		var start = Status.Pos;
		var buf = new List<W>();
		for(var i = 0;;i++){
			var c = NextChar(start);
			//var c2 =  PreRead();
			if( Eq(c , ']')){
				var c2 = NextChar(start);
				if( Eq(c2, ']') ){
					var value = new StrSegment{
						Start = start
						,Text = BufToStr(buf)
					};
					return value;
				}else{
					buf.Add(c);
					buf.Add(c2);
					continue;
				}
			}else{
				buf.Add(c);
			}

		}
	}

/// <summary>
/// 不改變狀態機、只往後讀字符
/// </summary>
/// <returns></returns>
	public I_StrSegment ReadPropKey(){
		var start = Status.Pos;
		var buf = new List<W>();
		for(;;){
			var c = NextByte();
			if( Eq(c , '|') ){
				var joined = BufToStr(buf);
				var key = new StrSegment{
					Start = start
					,Text = joined
				};
				return key;
			}
			buf.Add(c);
		}
	}

	// public bool isNil(word s){
	// 	if(s < 0){
	// 		return true;
	// 	}
	// 	return false;
	// }


	public Exception Error(str msg){
		var ex = new ParseErr(msg);
		ex.Pos = Status.Pos;
		ex.LineCol = Status.Line_col;
		throw ex;
		//return ex;
	}

	nil Metadata(){
		Status.Buffer.Add(Status.CurChar); // <
		var metadataStatus = 0; //0:<metadata>; 1:content; 2:</metadata>
		var bracesStack = new List<W>(); //元數據內json之大括號
		var metadataContent = new List<W>();
		for(;;){
			switch(metadataStatus){
				case 0: //<metadata>
					for(var j = 0; ;j++){
						var c = NextByte();
						//if( isNil(c) ){error("Unexpected EOF");return null!;}
						Buffer.Add(c);
						if( Eq(c , '>') ){
							if(Chk_metadataStartEtClr()){ // joined buffer is <metadata>
								metadataStatus = 1;
								break;
							}else{
								Error("Unexpected character\n");
							}
						}
					}
				break;
				case 1:
					for(;;){
						var c = NextByte();
						//if( isNil(c) ){error("Unexpected EOF"); return null!;}
						metadataContent.Add(c);
						if( Eq(c,'{') ){
							bracesStack.Add(c);
						}else if( Eq(c, '}') ){
							if(bracesStack.Count == 0){
								Error("metadata content is not valid json"); //大括號不配對
							}else{
								bracesStack.RemoveAt(bracesStack.Count-1);
								if(bracesStack.Count == 0){
									metadataStatus = 2;
									break;
								}
							}
						}
					}
				break;
				case 2: //</metadata>
					//除ᵣ末大括號到</metadata>間之空白
					for(;;){
						var c = NextByte();
						//if( isNil(c) ){error("Unexpected EOF");return null!;}
						if(IsWhite(c)){
							continue;
						}else if( Eq(c, '<') ){
							Buffer.Add(c);
							break;
						}else{
							Error("Unexpected character");
							return null!;
						}
					}

					for(;;){
						var c = NextByte();
						//if( isNil(c) ){error("Unexpected EOF");return null!;}
						Buffer.Add(c);
						if( Eq(c , '>') ){
							if(IsMetadataEnd(Buffer)){
								Buffer.Clear();
								//_status.metadataBuf = metadataContent;
								ParseMetadataBuffer(metadataContent);
								//_status.stack.Pop();
								Status.State = state_t.TopSpace;
								return null!;
								//break;
							}
						}
					}
				//break;
			}
		}
	}

	public bool IsWhite(str s){
		if(s == " "){return true;}
		if(s == "\t"){return true;}
		if(s == "\n"){return true;}
		if(s == "\r"){return true;}
		return false;
	}

	public bool IsWhite(W s){
		if( Eq(s , ' ') ){return true;}
		if( Eq(s , '\t') ){return true;}
		if( Eq(s , '\n') ){return true;}
		if( Eq(s , '\r') ){return true;}
		return false;
	}

	public bool Chk_metadataStartEtClr(){
		var ans = false;
		var buf = Buffer;
		if(IsMetadataStart(buf)){
			ans = true;
		}
		buf.Clear();
		return ans;
	}

	public bool IsMetadataStart(IList<W> buf){
		if(buf.Count == Tokens.s_metadataTag.Length){
			var joined = BufToStr(buf);

			if( Eq(joined , Tokens.s_metadataTag) ){
				return true;
			}
		}
		return false;
	}

	public bool IsMetadataEnd(IList<W> buffer){
		if(buffer.Count == Tokens.e_metadataTag.Length){
			var joined = BufToStr(buffer);
			if(Eq(joined , Tokens.e_metadataTag)){
				return true;
			}
		}
		return false;
	}

	//only for debug
	public static IList<str> ConcatBack(IList<I_DateBlock> dateBlocks){
		var ans = new List<str>();
		for(var i = 0; i < dateBlocks.Count; i++){
			var dateBlock = dateBlocks[i];
			ans.Add("[");
			ans.Add(dateBlock.Date.Text);
			ans.Add("]\n");
			for(var j = 0; j < dateBlock.Props.Count; j++){
				var prop = dateBlock.Props[j];
				ans.Add("[[");
				ans.Add(prop.Key.Text);
				ans.Add("|");
				ans.Add(prop.Value.Text);
				ans.Add("]]\n");
			}
			ans.Add("{{\n");
			for(var j = 0; j < dateBlock.Words.Count; j++){
				var word = dateBlock.Words[j];
				ans.Add(word.Head?.Text??"");
				for(var k = 0; k < word.Body.Count; k++){
					var body = word.Body[k];
					ans.Add(body.Text);
				}
				for(var k = 0; k < word.Props.Count; k++){
					var prop = word.Props[k];
					ans.Add("[[");
					ans.Add(prop.Key.Text);
					ans.Add("|");
					ans.Add(prop.Value.Text);
					ans.Add("]]\n");
				}
				ans.Add("````\n");
			}
		}
		return ans;
	}


}


/*
var txtLength = 1000000;
for(var i = 0; i < txtLength, i++){
	string c =  GetNextChar(); //c是只有一個碼點的字符串。從文件讀取。
	handle(c);
}
handle方法中會判斷c並把c加入到List<string>中。
以上代碼會有明顯的GC壓力或性能問題嗎?
 */



