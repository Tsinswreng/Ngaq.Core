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

	public Po_Kv PropToKv(I_Prop prop){
		var po_kv = new Po_Kv();
		po_kv.SetStr(prop.Key.Text, prop.Value.Text);
		return po_kv;
	}

	public IList<Bo_Word> Map(
		WordListTxtMetadata Metadata
		,IList<I_DateBlock> DateBlocks
	){
		if(Metadata.Belong is null){
			throw new Err_Base("Metadata.Belong is null");
		}
		var Ans = new List<Bo_Word>();
		foreach(var dateBlock in DateBlocks){
			var ua = new Bo_Word();
			ua.Po_Word.Lang = Metadata.Belong;
			foreach(var wordBlock in dateBlock.Words){
				foreach(var prop in wordBlock.Props){
					var po_kv = PropToKv(prop);
					ua.Props.Add(po_kv);
				}
				ua.Po_Word.WordFormId = wordBlock.Head.Text;

				var bodyStrList = new List<str>();
				foreach(var seg in wordBlock.Body){
					bodyStrList.Add(seg.Text);
				}
				var bodyStr = string.Join("\n", bodyStrList);
				var kv_meaning = new Po_Kv();
				kv_meaning.SetStr(
					Const_Tokens.Sep_NamespaceEtName+Const_PropKey.meaning
					,bodyStr
				);
				ua.Props.Add(kv_meaning);
			}

			foreach (var prop in dateBlock.Props){
				var po_kv = PropToKv(prop);
				ua.Props.Add(po_kv);
			}
			Ans.Add(ua);
		}
		return Ans;
	}
}
