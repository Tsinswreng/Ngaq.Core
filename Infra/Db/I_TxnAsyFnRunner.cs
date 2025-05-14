namespace Ngaq.Core.Infra.Db;

public interface I_TxnAsyFnRunner{
	public Task<T_Ret> TxnAsy<T_Ret>(
		Func<CancellationToken, Task<T_Ret>> FnAsy
		,CancellationToken ct
	);
}
