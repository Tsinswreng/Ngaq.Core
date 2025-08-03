//#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Po;
public  partial interface IPoBase: I_ShallowCloneSelf{
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
	public PoStatus Status{get;set;}
	#endregion IPoBase

[Obsolete]
	public enum EStatus{
		Normal = 0,
		Deleted = 1,
		Banned = 2,
	}

}
