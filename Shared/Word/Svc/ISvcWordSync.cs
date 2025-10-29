namespace Ngaq.Core.Shared.Word.Svc;

public interface ISvcWordSync{

	public Task<nil> AllWordsToServerNonStream(CT Ct);
}
