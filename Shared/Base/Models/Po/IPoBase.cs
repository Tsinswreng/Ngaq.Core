//#define Impl
namespace Ngaq.Core.Shared.Base.Models.Po;

using Ngaq.Core.Shared.User.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;

public partial interface IPoBase
	:I_ShallowCloneSelf
	,IAppSerializable
	,I_DelAt
{

	#region IPoBase
	/// <summary>
	/// 留與觸發器或攔截器、改實體保存旹自動改ᵣ「改ˡ時」ˇ
	/// </summary>
	public Tempus DbCreatedAt{get;set;}
	/// <summary>
	/// 留與觸發器或攔截器、增實體旹自動改ᵣ「添ˡ時」ˇ
	/// </summary>
	public Tempus DbUpdatedAt{get;set;}
	/// <summary>
	/// <舊>若用影子表 則 主表ʸ此字段璫必潙null、影子表㕥存既刪之條目、斯字段方有值</舊>
	/// </summary>
	// [Impl(typeof(I_DelAt))]
	// public IdDel DelAt{get;set;}

	#endregion IPoBase

}

public interface IBizCreateUpdateTime{
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

public static class ExtnBizTime{
	extension(IBizCreateUpdateTime z){
		public Tempus LatestBizTime{
			get{
				if(z.BizUpdatedAt.IsNullOrDefault()){
					return z.BizCreatedAt;
				}
				return z.BizUpdatedAt;
			}
		}
	}
}

interface I_{
	public IdUser? CreatedBy{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy
}
