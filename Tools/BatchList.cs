using System.Threading.Tasks;

namespace Ngaq.Core.Tools;


/// <summary>
/// 非線程安全
/// </summary>
/// <typeparam name="TItem"></typeparam>
/// <typeparam name="TRet"></typeparam>
public class BatchListAsy<TItem, TRet>
	:IDisposable
{
	public BatchListAsy(Func<
			IEnumerable<TItem>
			,CancellationToken
			,Task<TRet>
		> FnAsy
		,u64 BatchSize = 0xfff
	){
		this.FnAsy = FnAsy;
		this.BatchSize = BatchSize;
	}
	//public IList<TItem> FullList{get;set;} = new List<TItem>();
	public IList<TItem> UnHandledList{get;set;} = new List<TItem>();
	public u64 BatchSize{get;set;} = 0xfff;
	public Func<
		IEnumerable<TItem>
		,CancellationToken
		,Task<TRet>
	> FnAsy{get;set;}

	public async Task<TRet?> AddAsy(
		TItem item
		,CancellationToken ct
	){
		UnHandledList.Add(item);
		//FullList.Add(item);
		if((u64)UnHandledList.Count >= BatchSize){
			var Ans = await RunAsy(ct);
			return Ans;
		}
		return default;
	}

	bool _IsEnd{get;set;} = false;
	public async Task<TRet?> EndAsy(
		CancellationToken ct
	){
		if(_IsEnd){return default;}
		if((u64)UnHandledList.Count > 0){
			return await RunAsy(ct);
		}
		_IsEnd = true;
		return default;
	}

	protected nil Clear(){
		UnHandledList.Clear();
		return Nil;
	}

	protected async Task<TRet?> RunAsy(
		CancellationToken ct
	){
		var Ans = await FnAsy(UnHandledList, ct);
		Clear();
		return Ans;
	}


	public void Dispose(){
		if(!_IsEnd){
			EndAsy(default).Wait();
		}
	}


}
