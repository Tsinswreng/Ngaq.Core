using System.Threading.Tasks;

namespace Ngaq.Core.Tools;


/// <summary>
/// 非線程安全
/// </summary>
/// <typeparam name="T_Item"></typeparam>
/// <typeparam name="T_Ret"></typeparam>
public class BatchListAsy<T_Item, T_Ret>
	:IDisposable
{
	public BatchListAsy(Func<
			IEnumerable<T_Item>
			,CancellationToken
			,Task<T_Ret>
		> FnAsy
		,u64 BatchSize = 0xfff
	){
		this.FnAsy = FnAsy;
		this.BatchSize = BatchSize;
	}
	public IList<T_Item> FullList{get;set;} = new List<T_Item>();
	public IList<T_Item> UnHandledList{get;set;} = new List<T_Item>();
	public u64 BatchSize{get;set;} = 0xfff;
	public Func<
		IEnumerable<T_Item>
		,CancellationToken
		,Task<T_Ret>
	> FnAsy{get;set;}

	// public static async Task<nil> EndAll(
	// 	CancellationToken ct
	// 	,params BatchListAsy<T_Item, T_Ret>[] bls

	// ){//TODO
	// 	foreach(var bl in bls){
	// 		await bl.EndAsy(ct);
	// 	}
	// 	return Nil;
	// }

	public async Task<T_Ret?> AddAsy(
		T_Item item
		,CancellationToken ct
	){
		UnHandledList.Add(item);
		FullList.Add(item);
		if((u64)UnHandledList.Count >= BatchSize){
			return await RunAsy(ct);
		}
		return default;
	}

	bool _IsEnd{get;set;} = false;
	public async Task<T_Ret?> EndAsy(
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

	protected async Task<T_Ret?> RunAsy(
		CancellationToken ct
	){
		var ans = await FnAsy(UnHandledList, ct);
		Clear();
		return ans;
	}


	public void Dispose(){
		if(!_IsEnd){
			EndAsy(default).Wait();
		}
	}


}
