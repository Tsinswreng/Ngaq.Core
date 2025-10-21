#define Impl
namespace Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Domains.User.Models.Po;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Models.Po;


public partial class PoBase:IPoBase{
	public object ShallowCloneSelf()
#if Impl
	{
		return MemberwiseClone();
	}
#endif
	#region IPoBase
	public virtual Tempus CreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	public virtual Tempus DbCreatedAt{get;set;}
	=new();
	public virtual Tempus? UpdatedAt{get;set;} = default(Tempus);
	public virtual Tempus? DbUpdatedAt{get;set;}= default(Tempus);
	public IdUser? CreatedBy{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy

	public IdDel DelAt{get;set;}

	// [Obsolete]
	// public PoStatus Status{get;set;}
	#endregion IPoBase

}


public static class ExtnPoBase{
	public static bool IsDeleted(this IPoBase z){
		return z.DelAt != 0;
	}
}
