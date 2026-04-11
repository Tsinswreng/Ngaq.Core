namespace Ngaq.Core.Shared.Sync;

[Doc(@$"比較單個實體。
用于同步。
設把Remote合入Local。
")]
public class DtoEntityDiffEtSync<T>{
	[Doc(@$"
	0:一樣新;
	正數:Local更加新;
	負數:Remote更加新
	")]
	public i32 LocalCompareToRemote{get;set;}
	[Doc(@$"同步後的實體")]
	public T? SyncedEntity{get;set;}
}
