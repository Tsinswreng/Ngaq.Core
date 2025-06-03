namespace Ngaq.Core.Infra.Errors;

public class ErrArg:ErrBase,IErr{
	public ErrArg(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
}
