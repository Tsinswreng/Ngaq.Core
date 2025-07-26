using Ngaq.Core.Model.UserCtx;

namespace Ngaq.Core.Models.UserCtx;

public  partial class UserCtxMgr : IUserCtxMgr {
	public IUserCtx UserCtx = new UserCtx();
	public IUserCtx GetUserCtx() {
		return UserCtx;
	}
}
