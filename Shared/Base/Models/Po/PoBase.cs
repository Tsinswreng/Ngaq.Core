#define Impl
namespace Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.User.Models.Po;
using Ngaq.Core.Infra;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Tools;

public partial class PoBase:IPoBase{
	public object ShallowCloneSelf()
#if Impl
	{
		return MemberwiseClone();
	}
#endif
	#region IPoBase
	public virtual Tempus DbCreatedAt{get;set;}
	=new();
	public virtual Tempus DbUpdatedAt{get;set;}

	public IdDel DelAt{get;set;}

	#endregion IPoBase

}

public partial class PoBaseBizTime: PoBase, IBizCreateUpdateTime{
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


public static class ExtnPoBase{
	public static bool IsDeleted(this IPoBase z){
		return !z.DelAt.IsNullOrDefault();
	}
}
