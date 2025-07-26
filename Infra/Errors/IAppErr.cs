namespace Ngaq.Core.Infra.Errors;

public  partial interface IAppErr
	:IErr
	,I_Namespace
	,IId_Msg
	,IErrors//內ʹ錯
{


}


public static class ExtnIAppErr{
	public static ErrBase ToErrBase(
		this IAppErr z
	){
		var R = new ErrBase();
		R.Id = z.Id;
		R.Namespace = z.Namespace;
		R.Msg = z.Msg;
		R.Errors = z.Errors;
		return R;
	}
}
