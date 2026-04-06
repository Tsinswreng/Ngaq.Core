using Ngaq.Core.Shared.Word.Models.Po.NormLangToUserLang;
using Tsinswreng.CsPage;

namespace Ngaq.Core.Shared.Word.Models.Dto;

[Doc(@$"
{nameof(PoNormLangToUserLang)} 分頁查詢入參。
")]
public class ReqPageNormLangToUserLang{
	public IPageQry PageQry { get; set; }
	[Doc(@$"根據用戶自定義語言名稱做模糊查詢。
	#See[{nameof(PoNormLangToUserLang.UserLang)}]
	")]
	public str? UserLang { get; set; } = null;
}
