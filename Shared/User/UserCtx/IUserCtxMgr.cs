namespace Ngaq.Core.Shared.User.UserCtx;

/// <summary>
/// 似乎唯前端用及
/// </summary>
public partial interface IUserCtxMgr{
	IUserCtx GetUserCtx();
}

public partial interface IUserCtxMgr<T>
	where T : IUserCtx
{
	T GetUserCtxT();
}

