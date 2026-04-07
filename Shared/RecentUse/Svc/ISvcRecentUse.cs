using Ngaq.Core.Infra;
using Ngaq.Core.Shared.RecentUse.Models;
using Ngaq.Core.Shared.RecentUse.Models.Po.RecentUse;

namespace Ngaq.Core.Shared.RecentUse.Svc;

/// <summary>
/// 通用 recent-use 服務介面。
/// 僅定義契約，實現由 Local 層負責。
/// </summary>
[Doc($"{nameof(PoRecentUse)} 服務介面。")]
public interface ISvcRecentUse{
	/// <summary>
	/// 批量觸達 recent-use。
	/// 若記錄不存在則新增；存在則更新最近使用時間與次數。
	/// </summary>
	/// <param name="Ctx">數據庫用戶上下文。</param>
	/// <param name="Keys">要觸達的 recent-use 鍵集合。</param>
	/// <param name="Ct">取消令牌。</param>
	/// <returns>空值。</returns>
	public Task<nil> BatTouchRecentUse(
		IDbUserCtx Ctx,
		IAsyncEnumerable<RecentUseKey> Keys,
		CT Ct
	);

	/// <summary>
	/// 按鍵批量查詢 recent-use 實體。
	/// 返回序列與入參鍵序列一一對應，查無則返回 null。
	/// </summary>
	/// <param name="Ctx">數據庫用戶上下文。</param>
	/// <param name="Keys">recent-use 鍵集合。</param>
	/// <param name="Ct">取消令牌。</param>
	/// <returns>與入參對應的 recent-use 結果序列。</returns>
	public IAsyncEnumerable<PoRecentUse?> BatGetRecentUseByKey(
		IDbUserCtx Ctx,
		IAsyncEnumerable<RecentUseKey> Keys,
		CT Ct
	);
}

