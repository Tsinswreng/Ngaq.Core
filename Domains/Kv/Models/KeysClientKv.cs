namespace Ngaq.Core.Domains.Kv.Models;

using Tsinswreng.CsCfg;
using static Tsinswreng.CsCfg.CfgItem<obj?>;


public partial class KeysClientKv{
	public static ICfgItem<str> ClientId = Mk(null, [nameof(ClientId)], "");
	public static ICfgItem<str> UserId = Mk(null, [nameof(UserId)], "");
	public static ICfgItem<str> AccessToken = Mk(null, [nameof(AccessToken)], "");
	public static ICfgItem<str> RefreshToken = Mk(null, [nameof(RefreshToken)], "");

}
