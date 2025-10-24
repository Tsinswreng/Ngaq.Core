using Ngaq.Core.Tools;

namespace Ngaq.Core.Frontend.Kv;

using static Ngaq.Core.Tools.SlashSepKey;
using K = SlashSepKey;

public partial class KeysClientKv{
	public static K ClientId = Mk(null, [nameof(ClientId)]);
	public static K CurLocalUserId = Mk(null, [nameof(CurLocalUserId)]);
	public static K CurLoginUserId = Mk(null, [nameof(CurLoginUserId)]);
	/// <summary>
	/// 未必潙明文
	/// </summary>
	public static K RefreshToken = Mk(null, [nameof(RefreshToken)]);
	public static K RefreshTokenExpireAt = Mk(null, [nameof(RefreshTokenExpireAt)]);//i64
}
