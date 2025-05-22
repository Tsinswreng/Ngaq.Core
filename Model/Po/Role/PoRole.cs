#define Impl
using Ngaq.Core.Model.Po.User;

namespace Ngaq.Core.Model.Po.Role;

public class PoRole: IPoBase{
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
