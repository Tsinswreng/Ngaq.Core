namespace Ngaq.Core.Frontend.User;

using Ngaq.Core.Shared.User.UserCtx;

public class FrontendUserCtxMgr:IUserCtxMgr, IUserCtxMgr<IFrontendUserCtx>{
	protected static FrontendUserCtxMgr? _Inst = null;
	public static FrontendUserCtxMgr Inst => _Inst??= new FrontendUserCtxMgr();
	public IFrontendUserCtx UserCtx{get;set;} = new FrontendUserCtx();
	public IUserCtx GetUserCtx(){
		return UserCtx;
	}

	public IFrontendUserCtx GetUserCtxT(){
		return UserCtx;
	}
}

