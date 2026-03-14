namespace Ngaq.Core.Shared.Word.Svc;

using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Tools.Io;
using Ngaq.Core.Iter;
using Tsinswreng.CsPage;
using Tsinswreng.CsTools;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Tools;
using Ngaq.Core.Shared.Word.Models.Po.Word;

file class DirDoc{
	str Doc =
$$"""
#Sum[

]
#Descr[

]
""";
}

public partial interface ISvcWord{
//TODO 加詞後 宜予回饋 如 新ʹ加ʹ詞ʹ數 及 老詞新加之數
	public Task<nil> AddWordsFromFilePath(
		IUserCtx UserCtx
		,Path_Encode Path_Encode
		,CT Ct
	);

	public Task<nil> AddWordsFromText(
		IUserCtx UserCtx
		,string Text
		,CT Ct
	);

	public Task<nil> AddEtMergeWords(
		IUserCtx UserCtx
		,IEnumerable<IJnWord> JnWords
		,CT Ct
	);

	public Task<IPageAsyE<IJnWord>> PageWord(
		IUserCtx UserCtx
		,IPageQry PageQry
		,CT Ct
	);

	public Task<nil> AddWordId_PoLearnss(
		IUserCtx UserCtx
		,IEnumerable<WordId_PoLearns> WordId_PoLearnss
		,CT Ct
	);

	[Doc(@$"爲單詞插入新的學習記錄、並更新{nameof(PoWord.BizUpdatedAt)}")]
	public Task<nil> AddWordId_LearnRecordss(
		IUserCtx UserCtx
		,IEnumerable<WordId_LearnRecords> WordId_LearnRecordss
		,CT Ct
	);

	[Doc($$"""
	從多個獨立的 {{nameof(JnWord)}} json字符串 添加單詞 ???
	#Params(
		[],
		[每個元素都是一個獨立的 {{nameof(JnWord)}} json字符串],
		[],
	)
	""")]
	public Task<nil> AddWordsByJsonLineIter(
		IUserCtx User
		,IAsyncEnumerable<str> JsonLineIter
		,CT Ct
	);

	
	[Doc(@$"軟刪、只設聚合根之{nameof(PoWord.DelAt)}、不改他ʹ資產")]
	public Task<nil> SoftDelJnWordsByIds(
		IUserCtx User
		,IEnumerable<IdWord> Ids
		,CT Ct
	);

	public Task<nil> UpdJnWord(IUserCtx User, IJnWord JnWord, CT Ct);

//test
	public Task<IPage<IJnWord>> PageChangedWordsWithDelWordsAfterTime(
		IUserCtx User
		,IPageQry PageQry
		,Tempus Tempus
		,CT Ct
	);

	public Task<IPage<IJnWord>> SearchWord(
		IUserCtx User
		,IPageQry PageQry
		,ReqSearchWord Req
		,CT Ct
	);

	[Obsolete]
	public Task<IPage<ITypedObj>> PageSearch(
		IUserCtx User
		,IPageQry PageQry
		,ReqSearchWord Req
		,CT Ct
	);

	public Task<DtoCompressedWords> ZipAllWordsJson(IUserCtx User, ReqPackWords ReqPackWords, CT Ct);

	public Task<nil> SyncCompressedWord(IUserCtx User, DtoCompressedWords Dto, CT Ct);

	public Task<TextWithBlob> PackAllWordsToTextWithBlobNoStream(IUserCtx User, ReqPackWords Req, CT Ct);

	public Task<nil> SyncFromTextWithBlob(IUserCtx User, TextWithBlob TextWithBlob, CT Ct);

	public Task<RespScltWordsOfLearnResultByTimeInterval> ScltAddedWordsByTimeInterval(
		ReqScltWordsOfLearnResultByTimeInterval Req
		,CT Ct
	);

}


