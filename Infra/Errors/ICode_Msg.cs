namespace Ngaq.Core.Infra.Errors;
public interface ICode_Msg:IErr{
	public i64 Code{get;set;}
	public str? Message{get;set;}

}
