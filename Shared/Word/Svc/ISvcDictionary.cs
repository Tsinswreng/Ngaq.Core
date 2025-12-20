using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models.Dto;

namespace Ngaq.Core.Shared.Word.Svc;


public interface ISvcDictionary{
	public Task<RespLookup> LookupAsy(
		IUserCtx User
		,ReqLookup Req
		,CT Ct
	);
}
