#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Models.Po;

public class PoBase:IPoBase{
	#region IPoBase
	public Tempus CreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	public Tempus DbCreatedAt{get;set;}
	public Tempus? UpdatedAt{get;set;}
	public Tempus? DbUpdatedAt{get;set;}
	public IdUser? CreatedBy{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy
	public PoStatus Status{get;set;}
	#endregion IPoBase

}
