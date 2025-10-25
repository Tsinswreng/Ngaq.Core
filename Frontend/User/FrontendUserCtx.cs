namespace Ngaq.Core.Frontend.User;

using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Shared.User.UserCtx;

public class FrontendUserCtx : UserCtx, IFrontendUserCtx{
	public str? AccessToken{get;set;}
	public str? RefreshToken{get;set;}
	public IdUser LocalUserId{get;set;}
	public IdUser LoginUserId{get;set;}
}

public static class ExtnUserCtxMgr{
	public static IFrontendUserCtx GetFrontendUserCtx(
		this IUserCtxMgr z
	){
		var userCtx = z.GetUserCtx();
		if(userCtx is IFrontendUserCtx f){
			return f;
		}
		throw new NotImplementedException();
	}
}
