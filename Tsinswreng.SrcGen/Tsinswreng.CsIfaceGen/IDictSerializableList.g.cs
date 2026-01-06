namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
public partial class AppJsonCtx : JsonSerializerContext {
	public static IList<JsonConverter> JsonConverters = [
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.Device.IdClient>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.IdDel>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Sys.Models.IdKv>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.Password.IdPassword>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Sys.Po.Permission.IdPermission>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter.IdPreFilter>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.RefreshToken.IdRefreshToken>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Role.IdRole>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.RolePermission.IdRolePermission>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan.IdStudyPlan>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.User.IdUser>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Sys.Po.UserRole.IdUserRole>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg.IdWeightArg>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator.IdWeightCalculator>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Word.IdWord>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Learn_.IdWordLearn>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Kv.IdWordProp>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Bo.Jwt.Jti>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Po.PoStatus>(),
new global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Infra.Tempus>(),
	];
}
