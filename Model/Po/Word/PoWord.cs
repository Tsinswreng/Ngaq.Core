#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Model.Po.Word;

// public class TestParent{
// 	public str ParentProperty{get;set;} = "1234";
// 	public void Test(){
// 		var z = new TestParent();
// 		DictCtx.ToDict(z);
// 	}
// }

public interface IPoWord
	:IPoBase
	,IHasId<IdWord>
	,IHeadLangWord
{

}

public class PoWord
	:IPoBase
	,IHasId<IdWord>
	,IHeadLangWord
	,IPoWord
{
	//public str SelfProperty{get;set;} = "5678";//t
	public static PoWord Example{get;set;} = new PoWord();

	public IdWord Id {get;set;} = new IdWord(); //不顯式調用構造器則內ʹValue 得零

	public IdUser Owner{get;set;}

	#region IPoBase
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
	#endregion IPoBase


	#region I_Po_Word

	/// <summary>
	/// 詞形標識
	/// </summary>
	public str Head{get;set;}
	#if Impl
		="";
	#endif


	public str Lang{get;set;}
	#if Impl
		="";
#endif

	#endregion I_Po_Word

	public override string ToString() {
		var Dict = DictCtx.ToDict(this);
		return ExtnIDict.Print(Dict);
	}

}
