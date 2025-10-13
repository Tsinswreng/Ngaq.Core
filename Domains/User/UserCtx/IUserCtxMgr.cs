using Ngaq.Core.Models.UserCtx;

namespace Ngaq.Core.Model.UserCtx;

public partial interface IUserCtxMgr{
	IUserCtx GetUserCtx();
}
