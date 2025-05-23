using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Model.Sys.Po.Password;


public class PoPassword
	:IPoBase
	,IHasId<IdPassword>
{
	public IdPassword Id{get;set;}
	public i64 Algo{get;set;}
	public str Text{get;set;}="";
	public str Salt{get;set;} ="";

	public IdUser UserId{get;set;}
	#region IPoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public IdUser? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy
	public i64 Status{get;set;}
	#endregion IPoBase
}
