//#define Impl
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Model.Po;
public interface IPoBase{
	#region IPoBase
	public i64 InsertedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public IdUser? CreatedBy{get;set;}
	/// <summary>
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public i64? CreatedAt{get;set;}
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy
	public i64 Status{get;set;}
	#endregion IPoBase

	public enum EStatus{
		Normal = 0,
		Deleted = 1,
		Banned = 2,
	}

}
