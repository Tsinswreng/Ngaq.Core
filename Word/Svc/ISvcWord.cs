using Ngaq.Core.Infra;
using Ngaq.Core.Infra.Page;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.UserCtx;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;

public interface ISvcWord{

	Task<nil> AddWordsFromFilePath(
		IUserCtx UserCtx
		,Path_Encode Path_Encode
		,CancellationToken ct
	);

	Task<nil> AddWordsFromText(
		IUserCtx UserCtx
		,string Text
		,CancellationToken ct
	);

	public Task<IPageAsy<JnWord>> PageBoWord(
		IUserCtx UserCtx
		,IPageQuery PageQry
		,CancellationToken Ct
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

