namespace Ngaq.Core.Infra.Core;

public struct Answer<T>()
	:IAnswer<T>
{
	public T? Data{get;set;}
	bool _Ok = false;
	public bool Ok{
		get{return _Ok;}
		set{_Ok = value;}
	}
	public ICollection<object?>? Errors{get;set;} = new List<object?>();
	public object Status{get;set;} = 0;
	public str? StatusType{get;set;}

}
