using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
using Ngaq.Core.Shared.Sync;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Ngaq.Core.Word.Models.Po.Word;
using Tsinswreng.CsErr;
using Tsinswreng.CsSql;
using Tsinswreng.CsTextWithBlob;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"
Word Service Version 2. for {nameof(JnWord)}
the old version is {nameof(ISvcWord)}, for it uses the pattern of FnXxx and returns inner function
and did not support well for batch operations.

一切涉及修改{nameof(JnWord)}的操作都要修改其 {nameof(PoWord.BizUpdatedAt)}
```cs
RepoWord.AsAppRepo().BatBizTouch()
```
")]
public interface ISvcWordV2{
	
	[Doc(@$"
	獲取全部待學習單詞。
	會被當前學習方案定義的預篩選器篩選。
	如果未定義學習方案 則返回用戶詞庫的所有單詞
	#See[{nameof(PreFilter)}]
	#See[{nameof(KeysClientKv.CurStudyPlanId)}]
	")]
	public IAsyncEnumerable<JnWord> GetWordsToLearn(
		IDbUserCtx Ctx, CT Ct
	);

	[Doc(@$"
	獲取全部待學習單詞。
	會被當前學習方案定義的預篩選器篩選。
	如果未定義篩選器 則返回用戶詞庫的所有單詞
	#See[{nameof(KeysClientKv.CurStudyPlanId)}]
	")]
	public IAsyncEnumerable<JnWord> GetWordsToLearn(
		IDbUserCtx Ctx, PreFilter? Prefilter, CT Ct
	);
	
	[Doc(@$"批量爲單詞插入新的學習記錄、並更新{nameof(PoWord.BizUpdatedAt)}。
	用于背單詞後 儲存學習結果
	")]
	public Task<nil> BatAddNewLearnRecord(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWordLearn> PoWordLearnAsyE, CT Ct
	);
	
	[Doc(@$"
	從生詞表中加入單詞 用于學習。
	來自生詞表的生單詞不應具有{nameof(JnWord.Learns)}、只有 {nameof(JnWord.Word)} 與 {nameof(JnWord.Props)}。
	遇到({nameof(PoWord.Head)}, {nameof(PoWord.Lang)})相同的 即合併其{nameof(JnWord.Props)}。
	//TODO 釋 合併理則
	會新增{nameof(ELearn.Add)}、
	按 新詞的總共的 新來的 {nameof(KeysProp.description)} 的數量
	決定 新增的{nameof(ELearn.Add)}的數量
	")]
	public Task<nil> BatAddNewWordToLearn(
		IDbUserCtx Ctx,
		IAsyncEnumerable<JnWord> Words, CT Ct
	);
	
	[Doc(@$"先把每個元素的Owner改成和Ctx中的用戶一致。
	然後用{nameof(IRepo<,>.BatAddAgg)}。
	#Throw[{nameof(KeysErr.Common.DataIllegalOrConflict)}][
		添加失敗時即拋。不做合併等處理
	]
	")]
	public Task<nil> BatAddJnWord(
		IDbUserCtx Ctx,
		IAsyncEnumerable<JnWord> Words, CT Ct
	);
	
	[Doc(@$"軟刪 整ʹ單詞 含附屬資產亦需被標爲軟刪")]
	public Task<nil> SoftDelJnWordInId(
		IDbUserCtx Ctx,
		IAsyncEnumerable<IdWord> Ids, CT Ct
	);
	
	[Doc(@$"大模型詞典 轉 用戶單詞。
	{nameof(PoWord.Lang)} : {nameof(ISvcNormLangToUserLang.GetUserLangByNormLang)}。
	不額外添加 {nameof(JnWord.Learns)}。
	#Throw[{nameof(KeysErr.Word.NormLangToUserLangIsNotMapped)}][
		用戶未配置映射
	]
	")]
	public Task<JnWord> LlmDictWordToJnWord(
		IDbUserCtx Ctx
		,IReqLlmDict Req
		,IRespLlmDict LlmDict, CT Ct
	);
	
	[Doc(@$"在{nameof(LlmDictWordToJnWord)}基礎上、
	爲 {nameof(JnWord.Learns)}添加一項 {nameof(ELearn.Add)}。
	時間設爲當前時間。
	")]
	public Task<JnWord> LlmDictWordToJnWordWithLearn(
		IDbUserCtx Ctx
		,IReqLlmDict Req
		,IRespLlmDict LlmDict, CT Ct
	);
	
	
	public Task<nil> BatUpdWordProp(
		IDbUserCtx Ctx, IAsyncEnumerable<PoWordProp> WordProps, CT Ct
	);
	
	public Task<nil> DelWordPropInId(
		IDbUserCtx Ctx, IAsyncEnumerable<IdWordProp> Ids, CT Ct
	);
	
	
	public Task<nil> DelWordLearnInId(
		IDbUserCtx Ctx, IAsyncEnumerable<IdWordLearn> Ids, CT Ct
	);
	
	[Doc(@$"
	先用傳入的{nameof(PoWord.Id)} 去庫裏查單詞、設查得的單詞爲 Old
	
	若Old和傳入的{nameof(PoWord.Id)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)}都相同、
	則直接更新其他不同字段、{nameof(RespUpdPoWord.HasUpdatedBizId)}=false
	
	若 Old和New 的 ({nameof(PoWord.Head)},{nameof(PoWord.Lang)})不同、
	就先調{nameof(BatUpdHeadLang)}、再以返回的Id爲基準、更新其他字段
	#Rtn[更新結果Dto。其{nameof(RespUpdPoWord.FinalId)}一定有值]
	")]
	public Task<IAsyncEnumerable<RespUpdPoWord>> BatUpdPoWord(
		IDbUserCtx Ctx, IAsyncEnumerable<PoWord> PoWords, CT Ct
	);
	
	[Doc(@$"更新單詞Id。
	此函數一般用于同步旹 {nameof(EDiffByBizIdResultForSync.IdNotEqual)} 按Id更小者爲準。
	(函數實現規則是把{nameof(Ids)}的Old改成New、上面只是說用途、不代表此函數的實現規則是按Id更小)
	")]
	public Task<nil> BatChangeId(
		IDbUserCtx Ctx, IAsyncEnumerable<(IdWord Old, IdWord New)> Ids, CT Ct
	);
	
	[Doc(@$"
	BizId即({nameof(PoWord.Head)},{nameof(PoWord.Lang)})。
	
	對入參中每項(Arg)、先用Arg.Id 查得數據庫中己存之實體 WordOfId;
	若WordOfId不存在則拋{nameof(KeysErr.Word.WordOfId__NotFound)}
	若WordOfId存在但Owner不同則拋{nameof(KeysErr.Common.PermissionDenied)};
	
	若WordOfId存在且WordOfId的BizId與Arg的相同則不管({nameof(EUpdBizIdResult.BizIdAlreadyEqual)});
	
	若WordOfId存在且WordOfId的BizId與Arg不同
	[
		先用WordOfId.BizId查庫得到 WordOfHeadLang ;
		if WordOfHeadLang 已被軟刪除 先取消他的軟刪除狀態;
		if WordOfHeadLang is null [ 即 作爲更改目標的BizId不存在,更改不衝突({nameof(EUpdBizIdResult.DataOfBizIdNotExist)})
			直接把 WordOfId 的 BizId 改成 Arg的 BizId ;
			改 業務更新時間;
		]else[ 即 WordOfHeadLang 不爲空 作爲更改目標的BizId已存在,更改衝突({nameof(EUpdBizIdResult.BizIdNotEqual)})
			把 WordOfId 設成已軟刪除;
			把WordOfId的資產({nameof(JnWord.Props)},{nameof(JnWord.Learns)})
			算成 WordOfHeadLang 的資產(改{nameof(I_WordId.WordId)}外鍵、爲移動洏非複製);改完之後WordOfId不再有任何資產
			更改有變動的實體的{nameof(PoWord.BizUpdatedAt)}。(資產實體不需要改更新時間、因爲 只是外鍵變了 內容沒變)
			設 返值Dto的{nameof(RespUpdBizId.FinalId)}爲 WordOfHeadLang.Id
		]
	]
	#Rtn[同位置的每個元素與入參一一對應、
	返回的Id都是最終基準Id
	]
	")]
	public IAsyncEnumerable<RespUpdBizId> BatUpdHeadLang(IDbUserCtx Ctx, IAsyncEnumerable<PoWord> PoWords, CT Ct);

	[Doc(@$"
		把{nameof(JnWords)}合入數據庫。
		BizId指業務層面之唯一標識、而非Id字段
		
		對每個元素:
		先去數據庫中 按({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)}) 查到舊詞Local(可能爲null);
		
		然後調用{nameof(ISvcWordInMem.SyncJnWord)}。
		然後調用{nameof(BatSyncByDto)}。
		#Rtn[亦返{nameof(DtoJnWordSyncResult)} 便于審計等]
	")]
	public IAsyncEnumerable<DtoJnWordSyncResult> BizSyncJnWordByBizId(
		IDbUserCtx Ctx, IAsyncEnumerable<JnWord> JnWords, CT Ct
	);
	
	[Doc(@$"調用{nameof(ISvcWordSync)}裏面的API來實現。
	
	")]
	public Task<nil> BatSyncByDto(
		IDbUserCtx Ctx,
		IAsyncEnumerable<DtoJnWordSyncResult> Dtos, CT Ct
	);
}

[Doc(@$"此接口下函數不作爲公共API。
只是把同步單詞時 按 遇到的不同分類 分成不同函數處理、方便測試
")]
public interface ISvcWordSync{
	[Doc(@$"{nameof(EDiffByBizIdResultForSync.NoChange)}")]
	public Task<nil> BatSync_NoChange(
		IDbUserCtx Ctx,
		IAsyncEnumerable<DtoJnWordSyncResult> Dtos, CT Ct
	);
	
	[Doc(@$"{nameof(EDiffByBizIdResultForSync.RemoteIsOlder)}")]
	public Task<nil> BatSync_RemoteIsOlder(
		IDbUserCtx Ctx,
		IAsyncEnumerable<DtoJnWordSyncResult> Dtos, CT Ct
	);
	
	[Doc(@$"{nameof(EDiffByBizIdResultForSync.LocalNotExist)}")]
	public Task<nil> BatSync_LocalNotExist(
		IDbUserCtx Ctx,
		IAsyncEnumerable<DtoJnWordSyncResult> Dtos, CT Ct
	);
	
	[Doc(@$"{nameof(EDiffByBizIdResultForSync.IdNotEqual)}")]
	public Task<nil> BatSync_IdNotEqual(
		IDbUserCtx Ctx,
		IAsyncEnumerable<DtoJnWordSyncResult> Dtos, CT Ct
	);
	

}
