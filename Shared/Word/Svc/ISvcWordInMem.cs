using System.Diagnostics.Contracts;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Ngaq.Core.Tools;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"針對 {nameof(JnWord)}。
純內存操作相關API 不涉及數據庫。
")]
public interface ISvcWordInMem{
	
	[Doc(@$"只")]
	[Pure]
	public int DiffByTime<TSelf>(
		TSelf X, TSelf Y
	)where TSelf:IBizCreateUpdateTime, I_DelAt
	{
		if(X.BizUpdatedAt == Y.BizUpdatedAt
			&& X.BizCreatedAt == Y.BizCreatedAt
			&& X.DelAt == Y.DelAt
		){
			return 0;
		}
		var xUpd = X.GetNewestBizUpdOrDelTime();
		var yUpd = Y.GetNewestBizUpdOrDelTime();
		if(X.BizCreatedAt == Y.BizCreatedAt){
			return xUpd.CompareTo(yUpd);
		}
		throw new Exception(Todo.I18n("BizCreatedAt 不相等"));
	}
	
	[Doc(@$"確保兩詞之{nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)}相同。
	此函數中則不再重複校驗。
	")]
	public int CompareJnWord(JnWord X, JnWord Y){
		if(X.BizUpdatedAt == Y.BizUpdatedAt
			&& X.BizCreatedAt == Y.BizCreatedAt
			&& X.DelAt == Y.DelAt
		){
			return 0;
		}
		var xUpd = X.Word.GetNewestBizUpdOrDelTime();
		var yUpd = Y.Word.GetNewestBizUpdOrDelTime();
		if(X.BizCreatedAt == Y.BizCreatedAt){
			return xUpd.CompareTo(yUpd);
		}
		// 兩 BizCreatedAt 不相同、說明是 新單詞 在兩節點中各自新添。
		// 此時則接收遠端合入。如是則當遠端再發起一次合入時 兩
		return -1;
		
	}
	
	[Doc(@$"
把{nameof(Remote)}合入{nameof(Local)}、純函數、返回新的合併後的對象。

若({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)})不同則拒絕合併、
拋出 {nameof(ItemsErr.Word.__And__IsNotSameUserWord)};
		
返回值的{nameof(JnWord.Word)}按{nameof(SyncPoWord)}處理。
對其餘 {nameof(JnWord.Props)} 和 {nameof(JnWord.Learns)}的每項:
	- 對于Id匹配者、則各自用 {nameof(SyncProp)}和{nameof(SyncLearn)}
	- 對于 {nameof(Remote)} 比 {nameof(Local)} 多出來的資產、則要加到反回值中。
	- 對于 {nameof(Remote)} 比 {nameof(Local)} 多出來的資產、不管。
	")]
	[Pure]
	public DtoJnWordSyncResult SyncJnWord(JnWord Local, JnWord? Remote);
	
	[Doc(@$"
	若{nameof(PoWordProp.Id)}不同則拒絕合併。
	以{nameof(DiffByTime)}決定誰最新。若Remote不比Local更加新則不動。
	")]
	[Pure]
	public DtoEntityDiffEtSync<PoWordProp> SyncProp(PoWordProp Local, PoWordProp Remote);
	
	[Doc(@$"見{nameof(SyncProp)} for {nameof(PoWordProp)}")]
	[Pure]
	public DtoEntityDiffEtSync<PoWordLearn> SyncLearn(PoWordLearn Local, PoWordLearn Remote);
	
	[Doc(@$"
	若({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)})不同則拒絕合併、
	拋出 {nameof(ItemsErr.Word.__And__IsNotSameUserWord)};
	
	以{nameof(DiffByTime)}決定誰最新。若Remote不比Local更加新則不動。。
	若{nameof(PoWord.Id)}不同 則返回值的Id爲 {nameof(PoWord.BizCreatedAt)}更小者 的Id。
	")]
	[Pure]
	public DtoEntityDiffEtSync<PoWord> SyncPoWord(PoWord Local, PoWord Remote);
	
	
}
