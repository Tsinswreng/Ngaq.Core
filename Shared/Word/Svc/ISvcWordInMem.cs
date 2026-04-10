using System.Diagnostics.Contracts;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"針對 {nameof(JnWord)}。
純內存操作相關API 不涉及數據庫。
")]
public interface ISvcWordInMem{
	

	
	[Doc(@$"
把{nameof(Other)}合入{nameof(Src)}、純函數、返回新的合併後的對象。

若({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)})不同則拒絕合併、
拋出 {nameof(ItemsErr.Word.__And__IsNotSameUserWord)};
		
返回值的{nameof(JnWord.Word)}按{nameof(SyncPoWord)}處理。
對其餘 {nameof(JnWord.Props)} 和 {nameof(JnWord.Learns)}的每項:
	- 對于Id匹配者、則各自用 {nameof(SyncProp)}和{nameof(SyncLearn)}
	- 對于 {nameof(Other)} 比 {nameof(Src)} 多出來的資產、則要加到反回值中。
	- 對于 {nameof(Other)} 比 {nameof(Src)} 多出來的資產、不管。
	")]
	[Pure]
	public DtoSyncResult SyncJnWord(JnWord Src, JnWord Other);
	
	[Doc(@$"
	若{nameof(PoWordProp.Id)}不同則拒絕合併。
	以{nameof(ExtnPoBase.GetNewestBizTime)}更大者爲準
	")]
	[Pure]
	public PoWordProp SyncProp(PoWordProp Src, PoWordProp Other);
	
	[Doc(@$"見{nameof(SyncProp)} for {nameof(PoWordProp)}")]
	[Pure]
	public PoWordLearn SyncLearn(PoWordLearn Src, PoWordLearn Other);
	
	[Doc(@$"
	若({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)})不同則拒絕合併、
	拋出 {nameof(ItemsErr.Word.__And__IsNotSameUserWord)};
	
	以{nameof(ExtnPoBase.GetNewestBizTime)}更大者爲準。
	若{nameof(PoWord.Id)}不同 則返回值的Id爲 {nameof(PoWord.BizCreatedAt)}更小者 的Id。
	")]
	[Pure]
	public PoWord SyncPoWord(PoWord Src, PoWord Other);
	
	
}
