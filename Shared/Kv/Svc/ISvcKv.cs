namespace Ngaq.Core.Shared.Kv.Svc;

using Ngaq.Core.Shared.Kv.Models;
using Ngaq.Core.Shared.User.Models.Po.User;


public partial interface ISvcKv{

	public Task<PoKv?> GetByOwnerEtKeyAsy(IdUser Owner, obj Key, CT Ct);
	public Task<nil> SetAsy(PoKv Po, CT Ct);
	public Task<nil> SetManyAsy(IEnumerable<PoKv> Pos, CT Ct);


	// [Obsolete]
	// public Task<PoKv?> GetByKStr(IUserCtx UserCtx, str Key, CT Ct);

	// [Obsolete]
	// public Task<nil> SetVStrByKStr(IUserCtx UserCtx, str Key, str Value, CT Ct);
	// [Obsolete]
	// public Task<nil> SetVI64ByKStr(IUserCtx UserCtx, str Key, i64 Value, CT Ct);

}
