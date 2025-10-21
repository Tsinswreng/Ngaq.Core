#define Impl
namespace Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Domains.User.Models.Po;
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
	public virtual Tempus DbCreatedAt{get;set;}
	=new();
	public virtual Tempus DbUpdatedAt{get;set;}

	public IdDel DelAt{get;set;}

	#endregion IPoBase

}


public static class ExtnPoBase{
	public static bool IsDeleted(this IPoBase z){
		return z.DelAt != 0;
	}
}
