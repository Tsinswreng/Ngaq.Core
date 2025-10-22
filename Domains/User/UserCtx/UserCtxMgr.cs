namespace Ngaq.Core.Domains.User.UserCtx;

public partial class UserCtxMgr : IUserCtxMgr {
	protected static UserCtxMgr? _Inst = null;
	public static UserCtxMgr Inst => _Inst??= new UserCtxMgr();

	public IUserCtx UserCtx = new FrontendUserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
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
