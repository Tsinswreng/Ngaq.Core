namespace Ngaq.Core.Model.UserCtx;

public class UserCtxMgr : I_UserCtxMgr {
	public I_UserCtx UserCtx = new UserCtx();
	public I_UserCtx GetUserCtx() {
		return UserCtx;
	}
}
