namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
public partial class AppJsonCtx : JsonSerializerContext {
	public static IList<JsonConverter> JsonConverters = [
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.IdDel>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Po.PoStatus>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Infra.Tempus>(),
	];
}
