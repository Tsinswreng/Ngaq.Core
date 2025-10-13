using Ngaq.Core.Models.Sys.Req;
using Ngaq.Core.Models.Sys.Resp;

namespace Ngaq.Core.Sys.Svc;

public partial interface ISvcUser{
	public Task<nil> AddUser(
		ReqAddUser ReqAddUser
		,CT Ct
	);

	public Task<RespLogin> Login(ReqLogin ReqLogin, CT Ct);

	public Task<nil> Logout(ReqLogout ReqLogout, CT Ct);
}


