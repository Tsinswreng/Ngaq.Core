namespace Ngaq.Core.Frontend.User;
using Ngaq.Core.Shared.User.UserCtx;

public interface IFrontendUserCtxMgr{
	/// <summary>
	/// 每次當返同一引用
	/// </summary>
	/// <returns></returns>
	public IFrontendUserCtx GetUserCtx();
}


