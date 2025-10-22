using Ngaq.Core.Infra.Core;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;
public  partial interface ISvcAddWord{

	Task<IAnswer<nil>> AddWordsFromFilePathAsy(Path_Encode Path_Encode);

	Task<IAnswer<nil>> AddWordsFromUrlAsy(str Path);

	Task<IAnswer<nil>> AddWordsFromTextAsy(str Text);

}
