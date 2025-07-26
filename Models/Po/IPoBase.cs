//#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Po;
public  partial interface IPoBase: I_ShallowCloneSelf{
	#region IPoBase
	public Tempus DbCreatedAt{get;set;}
	public Tempus? DbUpdatedAt{get;set;}
	/// <summary>
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
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
