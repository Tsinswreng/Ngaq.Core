using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Tools;

namespace Ngaq.Core.Frontend.Kv;

using static Ngaq.Core.Tools.SlashSepKey;
using K = SlashSepKey;

public partial class KeysClientKv{
	public static K ClientId = Mk(null, [nameof(ClientId)]);
	public static K CurLocalUserId = Mk(null, [nameof(CurLocalUserId)]);
	public static K CurLoginUserId = Mk(null, [nameof(CurLoginUserId)]);
	
	/// 未必潙明文
	
	public static K RefreshToken = Mk(null, [nameof(RefreshToken)]);
	public static K RefreshTokenExpireAt = Mk(null, [nameof(RefreshTokenExpireAt)]);//i64
	public static K CurStudyPlanId = Mk(null, [nameof(CurStudyPlanId)]);
	public class Dictionary{
		public static K _R = Mk(null, [nameof(Dictionary)]);
		[Doc(@$"
		大模型字典 用戶最近使用過的正規化語言。
		格式爲 {nameof(IList<NormLang>)} json。
		臨時存、最多只存16個、避免性能問題。
		")]
		public static K RecentUsedNormLangs = Mk(_R, [nameof(RecentUsedNormLangs)]);
	}
}
