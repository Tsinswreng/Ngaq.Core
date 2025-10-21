//#define Impl
namespace Ngaq.Core.Models.Po;

using Ngaq.Core.Domains.User.Models.Po;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;


public partial interface IPoBase
	:I_ShallowCloneSelf
	,IAppSerializable
{

	#region IPoBase
	/// <summary>
	/// 留與觸發器或攔截器、改實體保存旹自動改ᵣ「改ˡ時」ˇ
	/// </summary>
	public Tempus DbCreatedAt{get;set;}
	/// <summary>
	/// 留與觸發器或攔截器、增實體旹自動改ᵣ「添ˡ時」ˇ
	/// </summary>
	public Tempus? DbUpdatedAt{get;set;}
	/// <summary>
	/// 理則ₐ實體ˇ增ʹ時、如于單詞、則始記于文本單詞表中之時 即其CreatedAt、非 存入數據庫之時
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	/// <summary>
	/// 理則ₐ實體ˇ改ʹ時
	/// 如ʃ有ʹ子實體ˋ變˪、則亦宜改主實體或聚合根ʹUpdatedAt
	/// </summary>
	public Tempus? UpdatedAt{get;set;}
	public IdUser? CreatedBy{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy

	/// <summary>
	/// 若用影子表 則 主表ʸ此字段璫必潙null、影子表㕥存既刪之條目、斯字段方有值
	/// </summary>
	public IdDel DelAt{get;set;}

	// [Obsolete]
	// public PoStatus Status{get;set;}
	#endregion IPoBase

	// [Obsolete]
	// public enum EStatus{
	// 	Normal = 0,
	// 	Deleted = 1,
	// 	Banned = 2,
	// }

}
