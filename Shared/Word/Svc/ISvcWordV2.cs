using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Tsinswreng.CsErr;
using Tsinswreng.CsSql;

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
		IAsyncEnumerable<JnWord> PoWordAsyE, CT Ct
	);
	
	[Doc(@$"軟刪 整ʹ單詞 含附屬資產亦需被標爲軟刪")]
	public Task<nil> SoftDelJnWordInId(
		IDbUserCtx Ctx,
		IAsyncEnumerable<IdWord> Ids, CT Ct
	);
	
	[Doc(@$"大模型詞典 轉 用戶單詞。
	{nameof(PoWord.Lang)} : {nameof(ISvcNormLangToUserLang.GetUserLangByNormLang)}
	")]
	public JnWord LlmDictWordToJnWord(
		IDbUserCtx Ctx
		,IRespLlmDict LlmDict, CT Ct
	);
	
	// public Task<nil> BatUpdHeadLangById(
	// 	IDbUserCtx Ctx
	// );
	
	// [Doc(@$"
	// #See[{nameof(IRepo<,>.BatSoftUpdAgg)}]
	// 按 根實體之Id 匹配而改。
	// 會更新{nameof(PoWord.BizUpdatedAt)}。
	// 不允許更新 {nameof(PoWord.Owner)}。
	// 在執行更新之前先把入參的 {nameof(PoWord.Owner)}改成與 {nameof(Ctx)}中的用戶相同。
	// ")]
	// public Task<nil> BatSoftUpdJnWord(
	// 	IDbUserCtx Ctx
	// 	,IAsyncEnumerable<JnWord> JnWords
	// 	,CT Ct
	// );
	
}
