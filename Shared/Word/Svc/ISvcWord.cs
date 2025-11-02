namespace Ngaq.Core.Word.Svc;

using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Tools.Io;
using Ngaq.Core.Stream;
using Ngaq.Core.Word.Models.Dto;
using Tsinswreng.CsPage;
using Tsinswreng.CsTools;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Tools;

public partial interface ISvcWord{
//TODO 加詞後 宜予回饋 如 新ʹ加ʹ詞ʹ數 及 老詞新加之數
	Task<nil> AddWordsFromFilePath(
		IUserCtx UserCtx
		,Path_Encode Path_Encode
		,CT Ct
	);

	Task<nil> AddWordsFromText(
		IUserCtx UserCtx
		,string Text
		,CT Ct
	);

	Task<nil> AddEtMergeWords(
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

	public Task<nil> AddWordId_LearnRecordss(
		IUserCtx UserCtx
		,IEnumerable<WordId_LearnRecords> WordId_LearnRecordss
		,CT Ct
	);

	public Task<nil> AddWordsByJsonLineIter(
		IUserCtx User
		,IAsyncEnumerable<str> JsonLineIter
		,CT Ct
	);


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

	public Task<IPage<ITypedObj>> PageSearch(
		IUserCtx User
		,IPageQry PageQry
		,ReqSearchWord Req
		,CT Ct
	);

	public Task<DtoCompressedWords> ZipAllWordsJson(IUserCtx User, ReqPackWords ReqPackWords, CT Ct);

	public Task<nil> AddCompressedWord(IUserCtx User, DtoCompressedWords Dto, CT Ct);

	public Task<TextWithBlob> PackAllWordsToTextWithBlobNoStream(IUserCtx User, ReqPackWords Req, CT Ct);

	public Task<nil> AddFromTextWithBlob(IUserCtx User, TextWithBlob TextWithBlob, CT Ct);

}


