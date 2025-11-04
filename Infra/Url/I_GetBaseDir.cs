namespace Ngaq.Core.Infra.Url;

public interface I_GetBaseDir{
	/// <summary>
	/// 安卓應用之pwd皆根目錄。故叵直ᵈ由相對路徑㕥載入配置等。
	/// 宜皆由此㕥拼接路徑。
	/// </summary>
	/// <returns></returns>
	public str GetBaseDir();
}
