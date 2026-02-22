using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models.Dto;

namespace Ngaq.Core.Shared.Word.Svc;

[Obsolete("用Dictionary/下之碼")]
public interface ObsltISvcDictionary{
	public Task<RespLookup> LookupAsy(
		IUserCtx User
		,ReqLookup Req
		,CT Ct
	);
}
