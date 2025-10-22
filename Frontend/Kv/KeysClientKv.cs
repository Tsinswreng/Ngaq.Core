namespace Ngaq.Core.Frontend.Kv;

using Ngaq.Core.Infra.Url;
using static Ngaq.Core.Infra.Url.Url;


public partial class KeysClientKv{
	public static Url ClientId = Mk(null, [nameof(ClientId)]);
	public static Url CurLocalUserId = Mk(null, [nameof(CurLocalUserId)]);
	public static Url CurLoginUserId = Mk(null, [nameof(CurLoginUserId)]);
	public static Url RefreshTokenCipher = Mk(null, [nameof(RefreshTokenCipher)]);
}
