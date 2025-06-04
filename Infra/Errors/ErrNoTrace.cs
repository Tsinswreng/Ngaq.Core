namespace Ngaq.Core.Infra.Errors;

public class ErrApp
	:IAppErr
{
	public str? Id{get;set;}
	public str? Message{get;set;}
	public str? Namespace{get;set;}
	public IList<object?> Errors{get;set;} = new List<object?>();
}
