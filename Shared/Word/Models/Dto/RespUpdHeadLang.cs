using Ngaq.Core.Shared.Word.Models.Po.Word;
using Ngaq.Core.Shared.Word.Svc;

namespace Ngaq.Core.Shared.Word.Models.Dto;

[Doc(@$"
更改業務層唯一標識 結果枚舉
#See[{nameof(ISvcWordV2.BatUpdHeadLang)}]
僅列舉操作成功的情況
")]
public enum EUpdBizIdResult{
	Unknwon = 0,
	[Doc(@$"業務層唯一標識本已一致")]
	BizIdAlreadyEqual,
	BizIdNotEqual,
	DataOfBizIdNotExist,
	
}

[Doc(@$"
#See[{nameof(ISvcWordV2.BatUpdHeadLang)}]
")]
public class RespUpdHeadLang{
	public EUpdBizIdResult Result{get;set;}
	[Doc(@$"操作後 最終對應BizId 的 Id字段")]
	public IdWord? FinalId{get;set;}
}
