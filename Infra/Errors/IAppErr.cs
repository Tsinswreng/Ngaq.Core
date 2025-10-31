namespace Ngaq.Core.Infra.Errors;


/// <summary>
/// 應用基異常接口
/// </summary>
public partial interface IAppErr
	:IAppErrView
	,I_Errors//內ʹ錯
{
	public IErrItem? Type{get;set;}
}


public static class ExtnIAppErr{
	public static AppErr ToAppErr(
		this IAppErr z
	){
		var R = new AppErr();
		R.Key = z.Key;
		R.Errors = z.Errors;
		return R;
	}
}
