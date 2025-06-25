#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

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
	,I_Id<IdWord>
	,IHeadLangWord
	,I_BizTimeVer
{

}

public class PoWord
	:PoBase
	,I_Id<IdWord>
	,IHeadLangWord
	,IPoWord
{
	//public str SelfProperty{get;set;} = "5678";//t
	public static PoWord Example{get;set;} = new PoWord();

	public IdWord Id {get;set;} = new IdWord(); //不顯式調用構造器則內ʹValue 得零

	public IdUser Owner{get;set;}

	#region IPoWord

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

	#endregion IPoWord

	[Impl(typeof(I_BizTimeVer))]
	public Tempus BizTimeVer{get;set;}

	public override string ToString() {
		var Dict = CoreDictMapper.Inst.ToDictShallowT(this);
		return ExtnIDict.Print(Dict);
	}

}
