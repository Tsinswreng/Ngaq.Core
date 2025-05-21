#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.User;

namespace Ngaq.Core.Model.Po.Word;

// public class TestParent{
// 	public str ParentProperty{get;set;} = "1234";
// 	public void Test(){
// 		var z = new TestParent();
// 		DictCtx.ToDict(z);
// 	}
// }

public class Po_Word
	:I_PoBase
	,I_HasId<Id_Word>
	,I_Po_Word
{
	//public str SelfProperty{get;set;} = "5678";//t
	public static Po_Word Example{get;set;} = new Po_Word();

	public Id_Word Id {get;set;} = new Id_Word(); //不顯式調用構造器則內ʹValue 得零

	public IdUser Owner{get;set;}

	#region PoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public IdUser? CreatedBy{get;set;}
	/// <summary>
	/// 當關聯ʹ他表 更新旹、亦當更新此字段
	/// </summary>
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}
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
