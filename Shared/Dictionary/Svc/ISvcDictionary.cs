using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.User.UserCtx;

namespace Ngaq.Core.Shared.Dictionary.Svc;


[Doc("Llm Dictionary")]
public interface ISvcDictionary{
	public Task<IRespLlmDict> Lookup(IUserCtx User, IReqLlmDict Req, CT Ct);
}
