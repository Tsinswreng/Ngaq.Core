namespace Ngaq.Core.Infra.Core;

public struct Answer<T>()
	:I_Answer<T>
{
	public T? Data{get;set;}
	bool _Ok = false;
	public bool Ok{
		get{return _Ok;}
		set{
			if(Errors.Count == 0){
				_Ok = value;
			}
		}
	}
	public ICollection<object?> Errors{get;set;} = new List<object?>();
	public i64 Code{get;set;} = 0;
	public str? CodeType{get;set;}

}
