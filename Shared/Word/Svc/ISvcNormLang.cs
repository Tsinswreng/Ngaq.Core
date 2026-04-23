using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.Dictionary.Models.Po.NormLang;
using Ngaq.Core.Shared.Kv;
using Ngaq.Core.Shared.Word.Models.Dto;
using Tsinswreng.CsPage;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"{nameof(PoNormLang)}
所有涉及修改{nameof(PoNormLang)}的 都要更新 {nameof(PoNormLang.BizUpdatedAt)}。
")]
public interface ISvcNormLang{
	[Doc("根據標準語言標識與類型查詢單個語言。")]
	public IAsyncEnumerable<PoNormLang?> BatGetNormLangByTypeCode(
		IDbUserCtx Ctx,
		IAsyncEnumerable<(ELangIdentType, str)> Type_Code,
		CT Ct
	);

	public Task<nil> BatAddNormLang(
		IDbUserCtx Ctx,
		IAsyncEnumerable<PoNormLang> Pos,
		CT Ct
	);

	public Task<nil> BatUpdNormLang(
		IDbUserCtx Ctx,
		IAsyncEnumerable<PoNormLang> Pos,
		CT Ct
	);

	public Task<nil> BatSoftDelNormLang(
		IDbUserCtx Ctx,
		IAsyncEnumerable<PoNormLang> Pos,
		CT Ct
	);

	public Task<IPageAsyE<PoNormLang>> PageNormLang(
		IDbUserCtx Ctx,
		ReqPageNormLang Req,
		CT Ct
	);
	
	
	[Doc(@$"初始化內置語言。
	#See[{nameof(InitNormLang.GetNormLangList)}]。
	如果數據庫中已有衝突的 則跳過。
	")]
	public Task<nil> InitBuiltinNormLang(IDbUserCtx Ctx, CT Ct);
	
	[Doc(@$"批量查询标准语言的翻译名称。
	#Params([],[將翻譯爲何種語言], [待被翻譯的諸語言],[])
	#Examples([
	fn(ctx, zh-TW, [en, en-US, ja])
	-> ['英語', '英語(美國)', '日語']
	])
	實 返 格式 未必 與 例 全一致。 TranslatedName僅用于界面顯示。
	")]
	public IAsyncEnumerable<str> BatGetTranslatedName(
		IDbUserCtx Ctx, 
		INormLang TargetLang,
		IAsyncEnumerable<INormLang> NormLangs, CT Ct
	);
	
}
