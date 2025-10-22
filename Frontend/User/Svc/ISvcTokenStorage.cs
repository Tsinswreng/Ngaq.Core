namespace Ngaq.Core.Frontend.User.Svc;

public interface ISvcTokenStorage{
	public Task<str?> GetRefreshToken(CT Ct);
	public Task<nil> SetRefreshToken(str Token, CT Ct);
}

