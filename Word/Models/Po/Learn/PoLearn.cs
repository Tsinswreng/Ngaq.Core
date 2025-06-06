#define Impl
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Model.Po.Learn_;

// public class Po_Learn:Po_Kv{
// 	public static new Po_Learn Example{get;set;} = new Po_Learn();
// }


public partial class PoLearn
	:IPoBase
	,I_Id<IdLearn>
	,I_WordId
	//,IPoKv
{

	public static PoLearn Example{get;set;} = new PoLearn();

	public IdLearn Id { get; set; } = new IdLearn();

	public IdWord WordId{get;set;}

	public str LearnResult{get;set;}="";


	#region PoBase
	public i64 InsertedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public i64? CreatedAt{get;set;}
	public IdUser? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion PoBase



}
