namespace Ngaq.Core.Infra;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
[JsonSourceGenerationOptions(
	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
	ReadCommentHandling = JsonCommentHandling.Skip,
	UseStringEnumConverter = true,
	Converters = [
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.IdDel>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Po.PoStatus>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Infra.Tempus>),
	]
)]
public partial class AppJsonCtx{}
