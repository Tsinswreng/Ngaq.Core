namespace Ngaq.Core.Infra.Core;

public struct Answer<T>()
	:I_Answer<T>
{
	public T? Data{get;set;}
	public bool Ok{get;set;} = false;
	public ICollection<object?> Errors{get;set;} = new List<object?>();
	public i64 Code{get;set;} = 0;
	public str? CodeType{get;set;}
	// public static Answer<U> OkWith<U>(U data){
	// 	var ans = new Answer<U>{Data = data};
	// 	ans.Ok = true;
	// 	return ans;
	// }

}
