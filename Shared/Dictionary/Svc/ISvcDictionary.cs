using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.User.UserCtx;

namespace Ngaq.Core.Shared.Dictionary.Svc;

public interface ISvcDictionary{
	public Task<RespLlmDict> Lookup(IUserCtx User, ReqLlmDict Req, CT Ct);
}
