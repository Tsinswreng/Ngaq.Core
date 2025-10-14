namespace Ngaq.Core.Domains.User.Models.Resp;

using Ngaq.Core.Domains.Base.Models.Resp;
using Ngaq.Core.Models.Sys.Po.User;



public partial class RespLogin: IResp{
	public str? AccessToken{get;set;} = "";
	public str RefreshToken{get;set;} = "";
	public str UserIdStr{get;set;} = "";
	public PoUser? PoUser{get;set;}
}
