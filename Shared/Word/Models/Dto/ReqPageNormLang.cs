using Ngaq.Core.Shared.Dictionary.Models.Po.NormLang;
using Tsinswreng.CsPage;

namespace Ngaq.Core.Shared.Word.Models.Dto;

[Doc(@$"
{nameof(PoNormLang)} 分頁查詢入參。
")]
public class ReqPageNormLang{
	public IPageQry PageQry{get;set;}
	public str? SearchText{get;set;} = null;
}
