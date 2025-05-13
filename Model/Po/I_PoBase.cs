//#define Impl
using Ngaq.Core.Model.Po.User;

namespace Ngaq.Core.Model.Po;
public interface I_PoBase{
	#region I_PoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	//public str? CreatedBy{get;set;}
	public Id_User? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	//public str? LastUpdatedBy{get;set;}
	//public UInt128? Owner{get;set;}
	public Id_User? LastUpdatedBy{get;set;}//LastUpdatedBy
	public i64 Status{get;set;}
	#endregion
}
