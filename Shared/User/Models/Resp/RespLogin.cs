namespace Ngaq.Core.Shared.User.Models.Resp;

using Ngaq.Core.Shared.Base.Models.Resp;
using Ngaq.Core.Shared.User.Models.Po.User;



public partial class RespLogin: IResp{
	public str AccessToken{get;set;} = "";
	public str RefreshToken{get;set;} = "";
	public str UserId{get;set;} = "";
	public PoUser? PoUser{get;set;}
}
