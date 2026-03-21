using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Learn;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Shared.Word.Svc;

public interface ISvcWordV2{
	
	[Doc(@$"
	獲取全部待學習單詞。
	會被當前學習方案定義的預篩選器篩選。
	如果未定義學習方案 則返回用戶詞庫的所有單詞
	#See[{nameof(PreFilter)}]
	#See[{nameof(KeysClientKv.CurStudyPlanId)}]
	//Temp 當前未實現學習方案模塊、則默認實現先返回所有單詞。
	")]
	public Task<IAsyncEnumerable<JnWord>> GetWordsToLearn(
		IDbFnCtx? Ctx, IUserCtx User
	);

	[Doc(@$"
	獲取全部待學習單詞。
	會被當前學習方案定義的預篩選器篩選。
	如果未定義篩選器 則返回用戶詞庫的所有單詞
	#See[{nameof(KeysClientKv.CurStudyPlanId)}]
	")]
	public Task<IAsyncEnumerable<JnWord>> GetWordsToLearn(
		IDbFnCtx? Ctx, IUserCtx User, PreFilter? Prefilter
	);
	
	[Doc(@$"批量爲單詞插入新的學習記錄、並更新{nameof(PoWord.BizUpdatedAt)}。
	用于背單詞後 儲存學習結果
	")]
	public Task<nil> BatAddNewLearnRecord(
		IDbFnCtx? Ctx, IUserCtx User
		,IAsyncEnumerable<PoWordLearn> PoWordLearnAsyE
	);
	

}
