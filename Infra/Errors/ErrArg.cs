namespace Ngaq.Core.Infra.Errors;

public partial class ErrArg:ErrBase,IErr{
	public ErrArg(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
}
