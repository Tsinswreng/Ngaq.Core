namespace Ngaq.Core.Domains.Base.Models.Po;

using Ngaq.Core.Infra;



public partial interface I_BizTimeVer{
/// <summary>
/// 業務版本時間戳 非樂觀鎖ʹ版本
/// </summary>
	//[Impl(typeof(I_BizTimeVer))]
	public Tempus BizTimeVer{get;set;}
}
