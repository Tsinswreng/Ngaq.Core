namespace Ngaq.Core.Infra.Core;

public partial struct Answer<T>()
	:IAnswer<T>
{
	public T? Data{get;set;}
	bool _Ok = false;
	public bool Ok{
		get{return _Ok;}
		set{_Ok = value;}
	}
	public ICollection<obj?>? Errors{get;set;} = new List<obj?>();
	public obj Status{get;set;} = 0;
	public str? StatusType{get;set;}

}
