namespace Ngaq.Core.Model.UserCtx;

public class UserCtxMgr : IUserCtxMgr {
	public IUserCtx UserCtx = new UserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
}
