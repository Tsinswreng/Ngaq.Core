using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Shared.RecentUse.Models.Po.RecentUse;

/// <summary>
/// 通用「最近使用」記錄。
/// 一條記錄表示：某用戶在某業務場景下，最近一次使用了某個實體鍵。
/// </summary>
[Doc(@$"
通用 recent-use 表。
唯一鍵建議爲 (Owner, Biz, Scene, EntityType, EntityKey)。
")]
public partial class PoRecentUse
	: PoBaseBizTime
	, I_Id<IdRecentUse>
	, I_Owner
{
	/// <summary>
	/// 主鍵。僅作技術主鍵使用，不承載業務唯一語義。
	/// </summary>
	public IdRecentUse Id { get; set; } = new();

	/// <summary>
	/// 所屬用戶。
	/// </summary>
	public IdUser Owner { get; set; } = IdUser.Zero;

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
	/// 實體業務鍵（穩定鍵）。示例：NormLang 可使用 Type|Code。
	/// </summary>
	public str EntityKey { get; set; } = "";

	/// <summary>
	/// 累計使用次數。可用於同時間戳下的次級排序或分析。
	/// </summary>
	public i64 UsedCount { get; set; } = 0;
}

