namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Req;
public class ReqPackWords : BaseReq, IWordsPackInfo, I_Version{
	public Tempus CreatedAt{get;set;} = Tempus.Now();
	public EWordsPack Type{get;set;}
	public Version? Version{get; set;} = AppVersion.Inst.Version;
}
