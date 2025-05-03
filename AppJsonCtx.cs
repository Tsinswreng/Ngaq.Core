namespace Ngaq.Shared;
using System.Text.Json.Serialization;
using Ngaq.Core;

[JsonSourceGenerationOptions(
    //PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(Answer<object>))]
public partial class AppJsonCtx : JsonSerializerContext{

}
