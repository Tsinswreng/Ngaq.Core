namespace Ngaq.Core.Domains.User.UserCtx;

public partial class UserCtxMgr : IUserCtxMgr {
	public IUserCtx UserCtx = new UserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
}
