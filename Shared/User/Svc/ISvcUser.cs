namespace Ngaq.Core.Shared.User.Svc;

using Ngaq.Core.Shared.User.Models.Req;
using Ngaq.Core.Shared.User.Models.Resp;
using Ngaq.Core.Models.Sys.Req;



public partial interface ISvcUser{
	public Task<nil> AddUser(
		ReqAddUser ReqAddUser
		,CT Ct
	);

	public Task<RespLogin> Login(ReqLogin ReqLogin, CT Ct);

	public Task<nil> Logout(ReqLogout ReqLogout, CT Ct);
}


