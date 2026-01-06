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
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.Device.IdClient>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.IdDel>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Sys.Models.IdKv>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.Password.IdPassword>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Sys.Po.Permission.IdPermission>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter.IdPreFilter>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.RefreshToken.IdRefreshToken>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Role.IdRole>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Sys.Po.RolePermission.IdRolePermission>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan.IdStudyPlan>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Po.User.IdUser>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Sys.Po.UserRole.IdUserRole>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg.IdWeightArg>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator.IdWeightCalculator>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Word.IdWord>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Learn_.IdWordLearn>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Model.Po.Kv.IdWordProp>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Shared.User.Models.Bo.Jwt.Jti>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Models.Po.PoStatus>),
typeof(global::Ngaq.Core.Tools.JsonConvtr<global::Ngaq.Core.Infra.Tempus>),
	]
)]
public partial class AppJsonCtx{}
