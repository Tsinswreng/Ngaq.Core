namespace Ngaq.Core.Infra.Db;

public interface I_Transaction : IDisposable{
	public Task<nil> BeginAsy();
	public Task<nil> CommitAsy();
	public Task<nil> RollbackAsy();
}
