/* 
看
Ai.typ
再看Spec下
Db.typ
Entity.typ
SvcDao.typ
Test.typ

然後看
`
E:\_code\CsNgaq\Ngaq.Core\Shared\Word\Svc\ISvcWordV2.cs
E:\_code\CsNgaq\Ngaq.Local\Domains\Word\Svc\SvcWord.*.cs
`

我要搞 測試驅動開發
你先給我寫測試用例 針對 ISvcWordV2。
在這個文件夾裏面寫 E:\_code\CsNgaq\Ngaq.Test\proj\Ngaq.Local.Test\Domains\Word\SvcWord\
 */

using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
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
	//Temp 當前未實現學習方案模塊、則默認實現先返回所有單詞。
	")]
	public IAsyncEnumerable<JnWord> GetWordsToLearn(
		IDbFnCtx? Ctx, IUserCtx User
	);

	[Doc(@$"
	獲取全部待學習單詞。
	會被當前學習方案定義的預篩選器篩選。
	如果未定義篩選器 則返回用戶詞庫的所有單詞
	#See[{nameof(KeysClientKv.CurStudyPlanId)}]
	")]
	public IAsyncEnumerable<JnWord> GetWordsToLearn(
		IDbFnCtx? Ctx, IUserCtx User, PreFilter? Prefilter
	);
	
	[Doc(@$"批量爲單詞插入新的學習記錄、並更新{nameof(PoWord.BizUpdatedAt)}。
	用于背單詞後 儲存學習結果
	")]
	public Task<nil> BatAddNewLearnRecord(
		IDbFnCtx? Ctx, IUserCtx User
		,IAsyncEnumerable<PoWordLearn> PoWordLearnAsyE
	);
	
	[Doc(@$"
	從生詞表中加入單詞 用于學習。
	來自生詞表的生單詞不應具有{nameof(JnWord.Learns)}、只有 {nameof(JnWord.Word)} 與 {nameof(JnWord.Props)}。
	遇到({nameof(PoWord.Head)}, {nameof(PoWord.Lang)})相同的 即合併其{nameof(JnWord.Props)}
	會新增{nameof(ELearn.Add)}、
	按 新詞的總共的 新來的 {nameof(KeysProp.description)} 的數量
	決定 新增的{nameof(ELearn.Add)}的數量
	")]
	public Task<nil> BatAddNewWordToLearn(
		IDbFnCtx? Ctx, IUserCtx User,
		IAsyncEnumerable<PoWord> PoWordAsyE
	);
	
}
