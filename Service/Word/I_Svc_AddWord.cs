using Ngaq.Core.Infra;

namespace Ngaq.Core.Service.Word;
public interface I_Svc_AddWord{

	Task<I_Answer<nil>> AddWordsFromFilePathAsy(str Path);

	Task<I_Answer<nil>> AddWordsFromUrlAsy(str Path);

	Task<I_Answer<nil>> AddWordsFromTextAsy(str Text);

}
