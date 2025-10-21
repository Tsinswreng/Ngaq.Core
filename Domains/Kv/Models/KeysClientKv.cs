namespace Ngaq.Core.Domains.Kv.Models;

using Ngaq.Core.Infra.Url;
using Tsinswreng.CsCfg;
using static Ngaq.Core.Infra.Url.Url;


public partial class KeysClientKv{
	public static Url ClientId = Mk(null, [nameof(ClientId)]);
	public static Url CurLocalUserId = Mk(null, [nameof(CurLocalUserId)]);
	public static Url AccessToken = Mk(null, [nameof(AccessToken)]);
	public static Url RefreshToken = Mk(null, [nameof(RefreshToken)]);
}
