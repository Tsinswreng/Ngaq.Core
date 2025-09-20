using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

[JsonSerializable(typeof(Dictionary<string, object?>))]
[JsonSerializable(typeof(IDictionary<string, object?>))]
[JsonSerializable(typeof(List<object?>))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(float))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(decimal))]
[JsonSerializable(typeof(DateTime))]
[JsonSerializable(typeof(DateTimeOffset))]
[JsonSerializable(typeof(Guid))]
internal partial class DictJsonCtx : JsonSerializerContext
{
}


public class DictJson{
	static JsonSerializerOptions Opt = new JsonSerializerOptions{
		//WriteIndented = true
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 允許原樣輸出
		,PropertyNamingPolicy = null  // 关闭命名策略
		,TypeInfoResolver = DictJsonCtx.Default
		,ReadCommentHandling = JsonCommentHandling.Skip
	};
	public static str ToJson(IDictionary<string, object?> data){
		//string json = JsonSerializer.Serialize(data, DictJsonCtx.Default.DictionaryStringObject); // 這樣不報錯、但是會把漢字轉成unicode碼
		string json = JsonSerializer.Serialize(data, Opt);
		return json;
	}
}
