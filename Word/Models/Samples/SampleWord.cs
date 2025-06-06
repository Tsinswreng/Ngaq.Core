using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Model.Samples.Word;

public class SampleWord{
	protected static SampleWord? _Inst = null;
	public static SampleWord Inst => _Inst??= new SampleWord();

	//public BoWord BoWord{get;set;} = new();
	public IList<JnWord> Samples = new List<JnWord>();



	public SampleWord(){
		{
			var o = Hello();
			Samples.Add(o);
		}
		{
			var o = 持て成す();
			Samples.Add(o);
		}
	}


	JnWord 持て成す(){
		var P = KeysProp.Inst;
		var L = ConstLearn.Inst;
		var T = ConstTokens.Inst;
		var Ans = new JnWord();
		Ans.PoWord = new();
		{var o = Ans.PoWord;
			o.Head = "持て成す";
			o.Lang = "Japanese";
			o.Owner = new IdUser();
			o.UpdatedAt = 1748422873848;
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.description,
"""
持て成す
もてなす
ピン留め
 単語を追加
英訳・英語 welcome、receive、host
"""
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.description,
"""
もてなす
別表記：もて成す、持て成す

主に「待遇する」の意味で用いられる表現。
（2020年11月17日更新）
"""
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.summary,"招待"
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.source,"N2"
			);
		}
		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.note,"這是筆記"
			);
		}

		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Add;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Add;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Fgt;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Rmb;
		}
		return Ans;
	}



	JnWord Hello(){
		var P = KeysProp.Inst;
		var L = ConstLearn.Inst;
		var T = ConstTokens.Inst;
		var Ans = new JnWord();
		Ans.PoWord = new();
		{var o = Ans.PoWord;
			o.Head = "Hello";
			o.Lang = "English";
			o.Owner = new IdUser();
			o.UpdatedAt = 1748422873848;
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.description,
"""
hello
美: [heˈləʊ]
英: [həˈləʊ]
int.	你好；喂；您好；哈嘍
网絡	哈羅；哈囉；大家好
"""
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.description,
"""
hello
(also hullo)
英 [həˈləʊ]美 [həˈloʊ]
CET4 TEM4
int. 喂，你好（用于問候或打招呼）；喂，你好（打電話時的招呼語）；喂，你好（引起別人注意的招呼語）；<非正式>喂，嘿 (認為別人說了蠢話或分心)；<英，舊>嘿（表示驚訝）
n. 招呼，問候；（Hello）（法、印、美、俄）埃洛（人名）
v. 說（或大聲說）“喂”；打招呼
[ 复數 hellos 第三人稱單數 helloes 現在分詞 helloing 過去式 helloed 過去分詞 helloed ]
"""
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.summary,"你好"
			);
		}

		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.source,"A Brief History of Homo Sapiens"
			);
		}
		{
			var o = new PoKv();
			Ans.Props.Add(o);
			o.SetStrToken(
				null,P.note,"this is a note"
			);
		}

		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Add;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Add;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Fgt;
		}
		{
			var o = new PoLearn();
			Ans.Learns.Add(o);
			o.LearnResult = ELearn.Inst.Rmb;
		}
		return Ans;


	}

}
