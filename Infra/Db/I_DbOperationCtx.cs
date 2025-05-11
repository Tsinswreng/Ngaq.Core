namespace Ngaq.Core.Infra.Db;

public interface I_DbOperationCtx{
	public I_Transaction? Transaction { get; set; }
}
