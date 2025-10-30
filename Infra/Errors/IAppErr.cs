namespace Ngaq.Core.Infra.Errors;

/// <summary>
/// 應用基異常接口
/// </summary>
public partial interface IAppErr
	:IErr
	,I_Errors//內ʹ錯
{
	public str? Id{get;set;}
	public IList<obj?> Args { get; set; }
}


public static class ExtnIAppErr{
	public static ErrBase ToErrBase(
		this IAppErr z
	){
		var R = new ErrBase();
		R.Id = z.Id;
		R.Errors = z.Errors;
		return R;
	}
}
