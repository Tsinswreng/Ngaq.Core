namespace Ngaq.Core.Domains.Kv.Models;

using Ngaq.Core.Infra.Url;
using static Ngaq.Core.Infra.Url.Url;

public partial class KeysClientSecretKv{
	///臨時存。後宜移至系統級Essential
	public static Url AesSecret = Mk(null, [nameof(AesSecret)]);
}
