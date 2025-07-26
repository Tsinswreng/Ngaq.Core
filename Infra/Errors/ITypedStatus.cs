namespace Ngaq.Core.Infra.Errors;

public  partial interface ITypedStatus{
	/// <summary>
	/// 狀態標識 作錯誤碼等
	/// </summary>
	public object Status { get;set; }
	/// <summary>
	/// 類型/命名空間。(Status, Type)當唯一
	/// </summary>
	public str? StatusType { get;set; }
}
