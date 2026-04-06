using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.Dictionary.Models.Po.NormLang;
using Ngaq.Core.Shared.Word.Models.Dto;
using Tsinswreng.CsPage;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"{nameof(PoNormLang)}
所有涉及修改{nameof(PoNormLang)}的 都要更新 {nameof(PoNormLang.BizUpdatedAt)}。
")]
public interface ISvcNormLang{
	[Doc("根據標準語言標識與類型查詢單個語言。")]
	public Task<PoNormLang?> BatGetNormLangByTypeCode(
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
}
