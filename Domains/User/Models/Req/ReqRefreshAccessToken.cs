namespace Ngaq.Core.Domains.User.Models.Req;

using Ngaq.Core.Domains.Base.Models.Req;
using Ngaq.Core.Domains.User.Models.Po.User;



public class ReqRefreshAccessToken:IReq{
	public str? DevicesId{get;set;}
	public IdUser UserId{get;set;}
	public str RefreshToken{get;set;} = "";
}


