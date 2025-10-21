namespace Ngaq.Core.Domains.User.UserCtx;

public partial class UserCtxMgr : IUserCtxMgr {
	protected static UserCtxMgr? _Inst = null;
	public static UserCtxMgr Inst => _Inst??= new UserCtxMgr();

	public IUserCtx UserCtx = new UserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
}
