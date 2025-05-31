namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
using Ngaq.Core.Infra.Core;
using Ngaq.Core.Service.Parser;

[JsonSourceGenerationOptions(
	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(Answer<object>))]
[JsonSerializable(typeof(IAnswer<object>))]
[JsonSerializable(typeof(WordListTxtMetadata))]
[JsonSerializable(typeof(IDictionary<string, object>))]
public partial class AppJsonCtx : JsonSerializerContext {

}
