using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.User.UserCtx;

namespace Ngaq.Core.Shared.Dictionary.Svc;


[Doc("Llm Dictionary")]
public interface ISvcDictionary{
	public Task<IRespLlmDict> Lookup(IUserCtx User, IReqLlmDict Req, CT Ct);
	
	// [Doc(@$"#See[{nameof(KeysClientKv.Dictionary.RecentUsedNormLangs)}]")]
	// public Task<IList<NormLang>> GetRecentUsedNormLangs(
	// 	IDbUserCtx Ctx, CT Ct
	// );
	
}
