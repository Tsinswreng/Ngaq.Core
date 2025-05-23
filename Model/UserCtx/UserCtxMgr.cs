namespace Ngaq.Core.Model.UserCtx;

public class UserCtxMgr : I_UserCtxMgr {
	public IUserCtx UserCtx = new UserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
}
