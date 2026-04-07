using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Shared.RecentUse.Models;

/// <summary>
/// 最近使用記錄的業務唯一鍵。
/// 用此鍵描述「同一個用戶」在「同一業務場景」下的一條可覆蓋 recent 記錄。
/// </summary>
public class RecentUseKey : IAppSerializable{
	/// <summary>
	/// 業務域。示例：Dictionary、WordEditor。
	/// </summary>
	public str Biz { get; set; } = "";

	/// <summary>
	/// 業務子場景。示例：SelectSourceLang、SelectTargetLang。
	/// </summary>
	public str Scene { get; set; } = "";

	/// <summary>
	/// 實體類型標識。示例：NormLang、UserLang。
	/// </summary>
	public str EntityType { get; set; } = "";

	/// <summary>
	/// 實體業務鍵（穩定鍵），不建議使用「可重建會變」的主鍵 Id。
	/// 示例：NormLang 可使用 Type|Code。
	/// </summary>
	public str EntityKey { get; set; } = "";
}

