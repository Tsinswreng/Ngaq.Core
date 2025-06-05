namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
using Ngaq.Core.Infra.Core;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Service.Parser;
using Ngaq.Core.Word.Models.Learn_;

[JsonSourceGenerationOptions(
	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(Answer<object>))]
[JsonSerializable(typeof(IAnswer<object>))]
[JsonSerializable(typeof(WordListTxtMetadata))]
[JsonSerializable(typeof(IDictionary<string, object>))]
[JsonSerializable(typeof(JnWord))]
[JsonSerializable(typeof(IWordForLearn))]
public partial class AppJsonCtx : JsonSerializerContext {

}
