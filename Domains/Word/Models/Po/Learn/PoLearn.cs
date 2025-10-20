#define Impl
namespace Ngaq.Core.Word.Models.Po.Learn;

using Ngaq.Core.Domains.Word.Models.Learn_;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Po.Word;



// public  partial class Po_Learn:Po_Kv{
// 	public static new Po_Learn Example{get;set;} = new Po_Learn();
// }

/// <summary>
/// 不當改其CreatedAt與UpdatedAt。唯可刪實體
/// </summary>
public partial class PoWordLearn
	:PoBase
	,IPoBase
	,I_Id<IdWordLearn>
	,I_WordId
	//,IPoKv
{

	public static PoWordLearn Example{get;set;} = new PoWordLearn();

	public IdWordLearn Id { get; set; } = new IdWordLearn();

	public IdWord WordId{get;set;}

	public ELearn LearnResult{get;set;}= ELearn.Add;

}

public static partial class ExtnPoWordLearn{
	public static Tempus Time_(
		this PoWordLearn z
	){
		if(z.UpdatedAt == null){
			return z.CreatedAt;
		}
		return z.UpdatedAt.Value;
	}
}
