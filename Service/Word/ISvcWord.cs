using Ngaq.Core.Infra;
using Ngaq.Core.Infra.Page;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.UserCtx;
using Ngaq.Core.Service.Word.Learn_.Models;
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

	public Task<IPageAsy<JoinedWord>> PageBoWord(
		IUserCtx UserCtx
		,IPageQuery PageQry
		,CancellationToken Ct
	);

	public Task<nil> AddPoLearns(
		IUserCtx UserCtx
		,IdWord IdWord
		,IEnumerable<PoLearn> PoLearns
		,CT Ct
	);

	public Task<nil> AddLearnRecords(
		IUserCtx UserCtx
		,IdWord IdWord
		,IEnumerable<LearnRecord> LearnRecords
		,CT Ct
	);
}

