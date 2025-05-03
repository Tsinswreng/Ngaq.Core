namespace Ngaq.Core.Service.Parser;
public class WordListTxtMetadata{
	/// <summary>
	/// 語言
	/// </summary>
	public str? Belong{get;set;}
	/// <summary>
	/// 單詞分隔符
	/// </summary>
	public str? Delimiter{get;set;}

	public static WordListTxtMetadata Parse(str txt){
		var ans = System.Text.Json.JsonSerializer.Deserialize<WordListTxtMetadata>(txt);
		if(ans?.Belong == null || ans?.Delimiter == null){
			throw new Exception("ans?.belong == null || ans?.delimiter == null");
		}
		return ans;
	}
}