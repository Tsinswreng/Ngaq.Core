namespace Ngaq.Core.Frontend.User;

public class EvtArgUserCtxChanged : EventArgs{
	public IFrontendUserCtx? UserCtx{get;set;}
}

/// <summary>
/// 前端ViewModel 每次取UserCtx璫用 UserCtxMgr 洏非直ᵈ依賴注入UserCtx
/// </summary>
public interface IFrontendUserCtxMgr{
	/// <summary>
	/// 每次當返同一引用
	/// </summary>
	/// <returns></returns>
	public IFrontendUserCtx GetUserCtx();
	public nil SetUserCtx(IFrontendUserCtx UserCtx);
	public event EventHandler<EvtArgUserCtxChanged>? OnUserCtxChanged;

}


