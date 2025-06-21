using Ngaq.Core.Infra;

namespace Ngaq.Core.Models.Po;

public interface I_BizVerTime{
/// <summary>
/// 業務版本時間戳 非樂觀鎖ʹ版本
/// </summary>
	public Tempus BizVerTime{get;set;}
}
