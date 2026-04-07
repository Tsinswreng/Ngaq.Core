using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.Dictionary.Models.Po.NormLang;
using Ngaq.Core.Shared.Kv;
using Ngaq.Core.Shared.User.UserCtx;

namespace Ngaq.Core.Shared.Dictionary.Svc;


[Doc("Llm Dictionary")]
public interface ISvcDictionary{
	public Task<IRespLlmDict> Lookup(IUserCtx User, IReqLlmDict Req, CT Ct);
	
	// [Doc(@$"#See[{nameof(KeysClientKv.Dictionary.RecentUsedNormLangs)}]")]
	// public Task<IList<NormLang>> GetRecentUsedNormLangs(
	// 	IDbUserCtx Ctx, CT Ct
	// );
	
	[Doc(@$"
		詞典當前設定的源語言
		#See[{nameof(KeysKv.Dictionary.CurSrcLang)}]
	")]
	public Task<PoNormLang?> GetCurSrcNormLang(IDbUserCtx Ctx, CT Ct);
	
	[Doc(@$"
		詞典當前設定的源語言
		#See[{nameof(KeysKv.Dictionary.CurSrcLang)}]
	")]
	public Task<PoNormLang?> SetCurSrcNormLang(
		IDbUserCtx Ctx, PoNormLang Po, CT Ct
	);
	
	[Doc(@$"
		詞典當前設定的目標語言
		#See[{nameof(KeysKv.Dictionary.CurTgtLang)}]
	")]
	public Task<PoNormLang?> GetCurTgtNormLang(IDbUserCtx Ctx, CT Ct);
	
	[Doc(@$"
		詞典當前設定的目標語言
		#See[{nameof(KeysKv.Dictionary.CurTgtLang)}]
	")]
	public Task<PoNormLang?> SetCurTgtNormLang(IDbUserCtx Ctx, CT Ct);
	
}
