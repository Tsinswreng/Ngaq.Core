#define Impl
namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Req;
public class ReqPackWords : BaseReq, IWordsPackInfo{
	public Tempus CreatedAt{get;set;} = Tempus.Now();
	public EWordsPack Type{get;set;} = EWordsPack.None;
	public Version? VerJnWord{get;set;} = JnWord.ClassVer;
	public Version? Ver{get;set;}
	#if Impl
	= IWordsPackInfo.ClassVer;
	#endif
	public Version? VerApp{get; set;}
	#if Impl
	= AppVer.Inst.Ver;
	#endif
}
