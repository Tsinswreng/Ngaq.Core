using Ngaq.Core.Infra.Core;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;
public interface ISvcAddWord{

	Task<I_Answer<nil>> AddWordsFromFilePathAsy(Path_Encode Path_Encode);

	Task<I_Answer<nil>> AddWordsFromUrlAsy(str Path);

	Task<I_Answer<nil>> AddWordsFromTextAsy(str Text);

}
