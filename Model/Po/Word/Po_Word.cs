#define Impl
using Ngaq.Core.Model.Po.User;

namespace Ngaq.Core.Model.Po.Word;

public class Po_Word
	:I_PoBase
	,I_Id<Id_Word>
	,I_Po_Word
{
	public static Po_Word Example{get;set;} = new Po_Word();

	public Id_Word Id {get;set;}

	public Id_User Owner{get;set;}

	#region PoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public Id_User? CreatedBy{get;set;}
	/// <summary>
	/// 當關聯ʹ他表 更新旹、亦當更新此字段
	/// </summary>
	public i64? UpdatedAt{get;set;}
	public Id_User? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion


	#region I_Po_Word

	/// <summary>
	/// 詞形標識
	/// </summary>
	public str WordFormId{get;set;}
	#if Impl
		="";
	#endif


	public str Lang{get;set;}
	#if Impl
		="";
	#endif

	#endregion I_Po_Word

}
