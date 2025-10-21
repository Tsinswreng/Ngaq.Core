#define Impl
namespace Ngaq.Core.Domains.Word.Models.Po.Word;

using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Po.Word;

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

	/// <summary>
	/// 最早入庫之時間
	/// CreatedAt潙 始誌于文本詞表之時
	/// 用于詞庫同步旹 比對㕥篩改˪ʹ詞
	/// </summary>
	public Tempus StoredAt{get;set;} = Tempus.Now();

	public override string ToString() {
		var Dict = CoreDictMapper.Inst.ToDictShallowT(this);
		return ExtnIDict.Print(Dict);
	}


	public class N{
		public str Id = nameof(PoWord.Id);
		public str Head = nameof(PoWord.Head);
		public str Lang = nameof(PoWord.Lang);
		public str Owner = nameof(PoWord.Owner);
		public str StoredAt = nameof(PoWord.StoredAt);
		public str CreatedAt = nameof(DbCreatedAt);
		public str UpdatedAt = nameof(DbUpdatedAt);
		public str CreatedBy = nameof(PoWord.CreatedBy);
		public str LastUpdatedBy = nameof(PoWord.LastUpdatedBy);
		public str DelId = nameof(PoWord.DelAt);
	}


}
