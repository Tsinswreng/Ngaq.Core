using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Req;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Tsinswreng.CsPage;
using Ngaq.Core.Infra;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Shared.StudyPlan.Models;

namespace Ngaq.Core.Shared.StudyPlan.Svc;

public interface ISvcStudyPlan{
	public Task<IWeightCalctr?> GetCurWeightCalctr(
		IDbUserCtx Ctx, CT Ct
	);
	
	public Task<IdStudyPlan?> GetCurStudyPlanId(
		IDbUserCtx Ctx, CT Ct
	);
	
	public Task<JnStudyPlan?> GetCurJnStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
	[Doc(@$"
	#See[{nameof(ExtnBoStudyPlan.FromJnStudyPlan)}]
	要帶緩存、在此接口之實現類中維護 CurBoStudyPlanCache、
	如後續再調用 {nameof(GetCurBoStudyPlan)}、先用 {nameof(GetCurStudyPlanId)}、
	若其Id與緩存之ID相同 且 {nameof(PoStudyPlan.BizUpdatedAt)} 未變 則返緩存
	")]
	public Task<BoStudyPlan?> GetCurBoStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	public Task<nil> SetCurStudyPlanId(
		IDbUserCtx Ctx
		,IdStudyPlan IdStudyPlan
		,CT Ct
	);
	public Task<nil> BatAddPreFilter(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoPreFilter> Pos
		,CT Ct
	);
	public Task<nil> BatAddWeightArg(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightArg> Pos
		,CT Ct
	);
	
	public Task<nil> BatAddWeightCalculator(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightCalculator> Pos
		,CT Ct
	);
	public Task<IPageAsyE<PoStudyPlan>> PageStudyPlan(
		IDbUserCtx Ctx
		,ReqPageStudyPlan Req
		,CT Ct
	);
	public Task<IPageAsyE<PoPreFilter>> PagePreFilter(
		IDbUserCtx Ctx
		,ReqPagePreFilter Req
		,CT Ct
	);
	public Task<IPageAsyE<PoWeightArg>> PageWeightArg(
		IDbUserCtx Ctx
		,ReqPageWeightArg Req
		,CT Ct
	);
	public Task<IPageAsyE<PoWeightCalculator>> PageWeightCalculator(
		IDbUserCtx Ctx
		,ReqPageWeightCalculator Req
		,CT Ct
	);
	
}
