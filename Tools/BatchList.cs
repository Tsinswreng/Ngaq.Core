using System.Runtime.CompilerServices;
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

	public async Task<TRet?> Add(
		TItem item
		,CancellationToken ct
	){
		UnHandledList.Add(item);
		//FullList.Add(item);
		if((u64)UnHandledList.Count >= BatchSize){
			var Ans = await Run(ct);
			return Ans;
		}
		return default;
	}


	public async IAsyncEnumerable<TRet?> AddRangeAsy(
		IEnumerable<TItem> items
		,[EnumeratorCancellation] CancellationToken Ct
	){
		//var Ans = new List<TRet>();
		foreach(var item in items){
			var Ret = await Add(item, Ct);
			yield return Ret;
			//Ans.Add(Ret.Value);
		}
		//return Ans;
	}


	bool _IsEnd{get;set;} = false;
	public async Task<TRet?> End(
		CancellationToken ct
	){
		if(_IsEnd){return default;}
		if((u64)UnHandledList.Count > 0){
			return await Run(ct);
		}
		_IsEnd = true;
		return default;
	}

	protected nil Clear(){
		UnHandledList.Clear();
		return Nil;
	}

	protected async Task<TRet?> Run(
		CancellationToken ct
	){
		var Ans = await FnAsy(UnHandledList, ct);
		Clear();
		return Ans;
	}


	public void Dispose(){
		if(!_IsEnd){
			End(default).Wait();
		}
	}


}
