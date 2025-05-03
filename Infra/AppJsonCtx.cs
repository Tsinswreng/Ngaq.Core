namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
using Ngaq.Core.Infra;

[JsonSourceGenerationOptions(
    //PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(Answer<object>))]
public partial class AppJsonCtx : JsonSerializerContext{

}
