using Ngaq.Core.Infra.Core;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Service.Parser.Model;

namespace Ngaq.Core.Service.Parser;

/// <summary>
/// 單詞表文本解析結果轉Bo_Word
/// </summary>
public class ParseResultMapper(){
	protected static ParseResultMapper? _Inst = null;
	public static ParseResultMapper Inst => _Inst??= new ParseResultMapper();


/// <summary>
/// TODO
/// 若key無命名空間 則須潙內置鍵 即Const_PropKey中ʃ有
/// 若有命名空間則檢格式 取末個「:」作分隔 如Tsinswreng:MyCustomPropKey。不合此格式則錯
/// </summary>
/// <param name="key"></param>
/// <returns></returns>
	public nil CheckPropKey(str key){

		return Nil;
	}

	public PoKv PropToKv(I_Prop prop){
		var po_kv = new PoKv();
		po_kv.SetStr(prop.Key.Text.Trim(), prop.Value.Text.Trim());
		return po_kv;
	}

	public IList<JoinedWord> Map(
		WordListTxtMetadata Metadata
		,IList<I_DateBlock> DateBlocks
	){
		if(Metadata.belong is null){
			throw new ErrBase("Metadata.Belong is null");
		}
		var Ans = new List<JoinedWord>();
		foreach(var dateBlock in DateBlocks){
			foreach(var wordBlock in dateBlock.Words){
				var ua = new JoinedWord();
				ua.PoWord.Lang = Metadata.belong;
				var trimedHead = wordBlock.Head?.Text?.Trim();
				if(trimedHead == null || str.IsNullOrEmpty(trimedHead)){
					continue;
				}
				foreach(var prop in wordBlock.Props){
					var po_kv = PropToKv(prop);
					ua.Props.Add(po_kv);
				}

				ua.PoWord.Head = trimedHead;

				var bodyStrList = new List<str>();
				foreach(var seg in wordBlock.Body){
					bodyStrList.Add(seg.Text.Trim());
				}
				var bodyStr = string.Join("\n", bodyStrList);
				var kv_meaning = new PoKv();
				kv_meaning.SetStrToken(
					null, KeysProp.Inst.description, bodyStr.Trim()
				);
				ua.Props.Add(kv_meaning);
				foreach (var prop in dateBlock.Props){
					var po_kv = PropToKv(prop);
					ua.Props.Add(po_kv);
				}
				Ans.Add(ua);
			}//~foreach(var wordBlock in dateBlock.Words)
		}//~foreach(var dateBlock in DateBlocks)
		return Ans;
	}
}
