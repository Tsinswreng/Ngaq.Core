#define Impl
namespace Ngaq.Core.Word.Models.Po.Learn;

using Ngaq.Core.Domains.Base.Models.Po;
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
	,IBizCreateUpdateTime
	//,IPoKv
{

	public static PoWordLearn Example{get;set;} = new PoWordLearn();

	public IdWordLearn Id { get; set; } = new IdWordLearn();

	public IdWord WordId{get;set;}

	public ELearn LearnResult{get;set;}= ELearn.Add;
#region IBizCreateUpdateTime
	/// <summary>
	/// 理則ₐ實體ˇ增ʹ時、如于單詞、則始記于文本單詞表中之時 即其CreatedAt、非 存入數據庫之時
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus BizCreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	/// <summary>
	/// 理則ₐ實體ˇ改ʹ時
	/// 如ʃ有ʹ子實體ˋ變˪、則亦宜改主實體或聚合根ʹUpdatedAt
	/// </summary>
	public Tempus BizUpdatedAt{get;set;}
	#if Impl
		= Tempus.Zero;
	#endif

	#endregion IBizCreateUpdateTime


}

public static partial class ExtnPoWordLearn{
	public static Tempus Time_(
		this PoWordLearn z
	){
		if(z.BizUpdatedAt.IsNullOrZero()){
			return z.BizCreatedAt;
		}
		return z.BizUpdatedAt.Value;
	}
}
