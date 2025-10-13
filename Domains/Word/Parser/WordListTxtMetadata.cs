using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;

namespace Ngaq.Core.Word.Parser;
public partial class WordListTxtMetadata: IAppSerializable{
	/// <summary>
	/// 語言
	/// 字段保持全小寫
	/// </summary>
	public str? belong{get;set;}
	/// <summary>
	/// 單詞分隔符
	/// 字段保持全小寫
	/// </summary>
	public str? delimiter{get;set;}

	public static WordListTxtMetadata Parse(str txt){
		//var ans = System.Text.Json.JsonSerializer.Deserialize<WordListTxtMetadata>(txt);
		var ans = JSON.parse<WordListTxtMetadata>(txt);
		if(ans?.belong == null || ans?.delimiter == null){
			throw new Exception("ans?.belong == null || ans?.delimiter == null");
		}
		return ans;
	}
}
