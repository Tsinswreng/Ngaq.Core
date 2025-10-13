namespace Ngaq.Core.Infra.Errors;

public partial class ErrBase
	:Exception
	,IErr
	,IAppErr
{
	public ErrBase(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
	public ErrBase(){}
	public str? Id { get; set; }
	public str? Namespace{get;set;} = "";
	public str? Msg { get; set; }
	public IList<object?> Errors { get; set; } = new List<object?>();
}
