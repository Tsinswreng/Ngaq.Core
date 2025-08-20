using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Tools.Io;
namespace Ngaq.Core.Word.Svc;

using Ngaq.Core.Models.UserCtx;
using Ngaq.Core.Word.Models;
using Tsinswreng.CsPage;

public  partial interface ISvcWord{

	Task<nil> AddWordsFromFilePath(
		IUserCtx UserCtx
		,Path_Encode Path_Encode
		, CT ct
	);

	Task<nil> AddWordsFromText(
		IUserCtx UserCtx
		,string Text
		, CT ct
	);

	public Task<IPageAsy<JnWord>> PageJnWord(
		IUserCtx UserCtx
		,IPageQry PageQry
		, CT Ct
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
}

