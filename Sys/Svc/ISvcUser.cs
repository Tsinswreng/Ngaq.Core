using Ngaq.Core.Model.Sys.Req;

namespace Ngaq.Core.Sys.Svc;

public interface ISvcUser{
	public Task<nil> AddUser(
		ReqAddUser ReqAddUser
		,CT Ct
	);
}

