using System.Diagnostics.Contracts;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Tsinswreng.CsTextWithBlob;

namespace Ngaq.Core.Shared.Sync;

public class EntitySyncerInMem<T>: IEntitySyncerInMem<T>
	where T: IPoBase, IBizCreateUpdateTime, I_Owner
{
	
}

[Doc(@$"適用於獨立的實體。
不適用于有資產實體的聚合(如{nameof(JnWord)})
也不適用于 屬于聚合的資產實體(如{nameof(PoWordProp)})
")]
public interface IEntitySyncerInMem<T>
	where T: IPoBase, IBizCreateUpdateTime, I_Owner
{
	
	[Doc(@$"只適用于資產。確保{nameof(X)}與{nameof(Y)}之Id相同、本函數不再校驗。")]
	[Pure]
	public int DiffPoByTime(
		T X, T Y
	){
		if(X.BizUpdatedAt == Y.BizUpdatedAt
			&& X.BizCreatedAt == Y.BizCreatedAt
			&& X.DelAt == Y.DelAt
		){
			return 0;
		}
		var xUpd = X.GetNewestBizUpdOrDelTime();
		var yUpd = Y.GetNewestBizUpdOrDelTime();
		return xUpd.CompareTo(yUpd);
		//throw new Exception(Todo.I18n("Id相同時 BizCreatedAt 不相等"));
	}
	
	
	[Doc(@$"適用于單個獨立的實體、不適用于聚合類(如{nameof(JnWord)})")]
	public IDtoEntityDiffEtSync<T> Sync(
		T Local, T Remote
	){
		if(!Local.Id_().EqObj(Remote.Id_())){
			throw new InvalidOperationException(Todo.I18n("Id不同時不應該同步"));
		}
		var diff = DiffPoByTime(Local, Remote);
		var r = new DtoEntityDiffEtSync<T>();
		r.LocalCompareToRemote = diff;
		if(diff == 0){
			r.SyncedEntity = default;
		}
		else if(diff > 0){
			r.SyncedEntity = Remote;
		}
		else{
			r.SyncedEntity = default;
		}
		return r;
	}
}

[Doc(@$"實際操作數據庫")]
public interface IEntitySyncerDb<T>{
	public IAsyncEnumerable<DtoEntityDiffEtSync<T>> BatSyncPo(
		IDbUserCtx Ctx, IAsyncEnumerable<T> Pos, CT Ct
	);
}
