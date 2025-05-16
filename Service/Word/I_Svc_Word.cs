using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.UserCtx;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;

public interface I_Svc_Word{

	Task<nil> AddWordsFromFilePathAsy(
		I_UserCtx UserCtx
		,Path_Encode Path_Encode
		,CancellationToken ct
	);

	Task<nil> AddWordsFromTextAsy(
		I_UserCtx UserCtx
		,string Text
		,CancellationToken ct
	);
}

