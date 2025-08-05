#define Impl
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Po.Word;

// public  partial class TestParent{
// 	public str ParentProperty{get;set;} = "1234";
// 	public void Test(){
// 		var z = new TestParent();
// 		DictCtx.ToDict(z);
// 	}
// }

public partial interface IPoWord
	:IPoBase
	,I_Id<IdWord>
	,IHeadLangWord
{
	/// <summary>
	/// 最早ʹ入庫ʹ時 作增量同步ʹʃ依
	/// 如某詞ʹCreatedAt早于LastUploadToRemoteTime
	/// 辨: CreatedAt: 詞ˋ始被錄于文本單詞表之時
	/// DbCreatedAt: 實體插入數據庫旹
	/// StoredAt: 詞ˋ始被錄入數據庫旹
	/// 備份同步旹、于同一詞、同步後本地與遠端之StoredAt當一致、DbCreatedAt可不一致
	/// </summary>
	public Tempus StoredAt{get;set;}
}

public partial class PoWord
	:PoBase
	,I_Id<IdWord>
	,IHeadLangWord
	,IPoWord
{
	//public str SelfProperty{get;set;} = "5678";//t
	public static PoWord Example{get;set;} = new PoWord();

/// <summary>
/// 僅用于臨時標識、詞ʹidˋ恐變
/// 欲做持久ʹ標識、宜用(Owner, Head, Lang)
/// 備份同步㕥合併同ʹ詞旹、當按詞頭洏非id㕥判兩詞是否潙同一詞、緣縱潙同ʹ詞、本地ʹ庫ʸ與遠端ᐪʹid恐不一
/// //TODO 一致ˢid、以CreatedAt最早者潙準
/// </summary>
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

	public Tempus StoredAt{get;set;} = Tempus.Now();

	public override string ToString() {
		var Dict = CoreDictMapper.Inst.ToDictShallowT(this);
		return ExtnIDict.Print(Dict);
	}

}
