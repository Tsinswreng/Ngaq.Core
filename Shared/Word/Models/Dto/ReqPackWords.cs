namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Req;
public class ReqPackWords : BaseReq, IWordsPackInfo, I_Version{
	public EWordsPack Type{get;set;}
}
