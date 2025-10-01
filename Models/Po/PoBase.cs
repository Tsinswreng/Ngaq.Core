#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po;
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Models.Po;

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
	public virtual Tempus? UpdatedAt{get;set;}
	public virtual Tempus? DbUpdatedAt{get;set;}
	public IdUser? CreatedBy{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy

	public IdDel? DelId{get;set;}

	// [Obsolete]
	// public PoStatus Status{get;set;}
	#endregion IPoBase

}
