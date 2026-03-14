namespace Ngaq.Core.Shared.Kv.Svc;

using Ngaq.Core.Shared.Kv.Models;
using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsSql;


/// TODO  增接口㕥刪(軟/硬);
public partial interface ISvcKv{
	[Obsolete]
	public Task<Func<
		IdUser
		,obj
		,CT, Task<PoKv?>
	>> FnGetByOwnerEtKey(IDbFnCtx Ctx, CT Ct);
	
	public Task<PoKv?> GetByOwnerEtKey(IdUser Owner, obj Key, CT Ct);

	[Obsolete]
	public Task<Func<
		PoKv
		,CT, Task<nil>
	>> FnSet(IDbFnCtx Ctx, CT Ct);

	[Obsolete]
	public Task<nil> Set(PoKv Po, CT Ct);

	[Obsolete]
	public Task<Func<
		IEnumerable<PoKv>
		,CT, Task<nil>
	>> FnSetMany(IDbFnCtx Ctx, CT Ct);
	public Task<nil> SetMany(IEnumerable<PoKv> Pos, CT Ct);

}
