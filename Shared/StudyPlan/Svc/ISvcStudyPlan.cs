using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.UserCtx;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Shared.StudyPlan.Svc;

public interface ISvcStudyPlan{
	public Task<nil> BatAddPreFilter(
		IDbFnCtx? Ctx
		,IUserCtx User
		,IAsyncEnumerable<PoPreFilter> Pos
		,CT Ct
	);
	public Task<nil> BatAddWeightArg(
		IDbFnCtx? Ctx
		,IUserCtx User
		,IAsyncEnumerable<PoWeightArg> Pos
		,CT Ct
	);
	public Task<nil> BatAddWeightCalculator(
		IDbFnCtx? Ctx
		,IUserCtx User
		,IAsyncEnumerable<PoWeightCalculator> Pos
		,CT Ct
	);
	
}
