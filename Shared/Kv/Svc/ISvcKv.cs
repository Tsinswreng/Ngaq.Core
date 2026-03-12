namespace Ngaq.Core.Shared.Kv.Svc;

using Ngaq.Core.Shared.Kv.Models;
using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsSql;


/// <summary>
/// TODO  增接口㕥刪(軟/硬);
/// </summary>
public partial interface ISvcKv{

	public Task<Func<
		IdUser
		,obj
		,CT, Task<PoKv?>
	>> FnGetByOwnerEtKey(IDbFnCtx Ctx, CT Ct);
	public Task<PoKv?> GetByOwnerEtKey(IdUser Owner, obj Key, CT Ct);


	public Task<Func<
		PoKv
		,CT, Task<nil>
	>> FnSet(IDbFnCtx Ctx, CT Ct);

	public Task<nil> Set(PoKv Po, CT Ct);

	public Task<Func<
		IEnumerable<PoKv>
		,CT, Task<nil>
	>> FnSetMany(IDbFnCtx Ctx, CT Ct);
	public Task<nil> SetMany(IEnumerable<PoKv> Pos, CT Ct);

}
