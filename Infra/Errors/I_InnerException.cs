namespace Ngaq.Core.Infra.Errors;

public interface I_InnerException{
	public Exception? InnerException { get; set;}
}
