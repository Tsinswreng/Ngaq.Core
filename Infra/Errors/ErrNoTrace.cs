namespace Ngaq.Core.Infra.Errors;

public partial class AppErr
	:IAppErr
{
	public str? Id{get;set;}
	public str? Msg{get;set;}
	public str? Namespace{get;set;}
	public IList<object?> Errors{get;set;} = new List<object?>();

	public override string ToString(){
		return Namespace+":"+Id+"\n"+Msg+str.Join("\n", Errors.Select(x=>x?.ToString()??""));
	}
}
