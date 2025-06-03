namespace Ngaq.Core.Infra.Errors;

public class ErrBase : Exception,IErr{
	public ErrBase(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}

	public ErrBase(){}

	public i64 Code { get; set; }
	public str Namespace{get;set;} = "";
}
