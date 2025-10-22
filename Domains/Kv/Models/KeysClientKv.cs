namespace Ngaq.Core.Domains.Kv.Models;

using Ngaq.Core.Infra.Url;
using static Ngaq.Core.Infra.Url.Url;


public partial class KeysClientKv{
	public static Url ClientId = Mk(null, [nameof(ClientId)]);
	public static Url CurLocalUserId = Mk(null, [nameof(CurLocalUserId)]);
	public static Url CurLoginUserId = Mk(null, [nameof(CurLoginUserId)]);
	public static Url AccessTokenCipher = Mk(null, [nameof(AccessTokenCipher)]);
	public static Url RefreshTokenCipher = Mk(null, [nameof(RefreshTokenCipher)]);
	///臨時存。後宜移至系統級Essential
	public static Url __TuupsTvysMritJewk = Mk(null, [nameof(__TuupsTvysMritJewk)]);
}
