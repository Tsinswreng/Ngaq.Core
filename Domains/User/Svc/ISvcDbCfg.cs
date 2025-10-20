using Ngaq.Core.Domains.User.Models;
using Ngaq.Core.Domains.User.UserCtx;

namespace Ngaq.Core.Sys.Svc;
public partial interface ISvcDbCfg{
	//[Impl(typeof(ISvcDbCfg))]
	public Task<PoKv?> GetOneByKStr(IUserCtx UserCtx, str Key, CT Ct);

	//[Impl(typeof(ISvcDbCfg))]
	public Task<nil> SetVStrByKStr(IUserCtx UserCtx, str Key, str Value, CT Ct);
	//[Impl(typeof(ISvcDbCfg))]
	public Task<nil> SetVI64ByKStr(IUserCtx UserCtx, str Key, i64 Value, CT Ct);

}
