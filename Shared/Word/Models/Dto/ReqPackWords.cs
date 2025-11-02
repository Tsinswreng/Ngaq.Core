namespace Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Base.Models.Req;
public class ReqPackWords : BaseReq, IWordsPackInfo{
	public EWordsPack Type{get;set;}
}
