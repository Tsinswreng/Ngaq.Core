namespace Ngaq.Core.Shared.Kv.Svc;

using Ngaq.Core.Shared.Kv.Models;
using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsSql;


/// TODO  增接口㕥刪(軟/硬);
[Doc(@$"#See[{nameof(PoKv)}]")]
public partial interface ISvcKv{
	public Task<IAsyncEnumerable<PoKv?>> BatGetByOwnerEtKey(
		IAsyncEnumerable<(IdUser, obj)> Owner_Key, CT Ct
	);
	
	public Task<nil> BatSet(IAsyncEnumerable<PoKv> Kvs, CT Ct);
}
