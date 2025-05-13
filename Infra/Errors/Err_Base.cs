namespace Ngaq.Core.Infra.Errors;

public class Err_Base : Exception{
	public Err_Base(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
}
