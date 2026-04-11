using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Kv;

namespace Ngaq.Core.Shared.Sync;

[Doc(@$"適用於獨立的實體。
不適用于有資產實體的聚合(如{nameof(JnWord)})
也不適用于 屬于聚合的資產實體(如{nameof(PoWordProp)})
")]
public interface IEntitySyncer<T>
	where T: IPoBase, IBizCreateUpdateTime, I_Owner
{
	
	public DtoEntityDiffEtSync<T> Sync(
		T Local, T Remote
	);
	
	public Task<nil> SyncPo(
		IDbUserCtx Ctx, IAsyncEnumerable<T> Pos, CT Ct
	);
	
	
}
