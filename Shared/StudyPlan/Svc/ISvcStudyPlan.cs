using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Req;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Tsinswreng.CsPage;
using Ngaq.Core.Infra;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Shared.StudyPlan.Models;
using Ngaq.Core.Shared.Word.WeightAlgo;
using Ngaq.Core.Frontend.Kv;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.WeightAlgo.Models;

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
	讀取用戶當前自指定的學習方案。
	若用戶未配置學習方案、雖實際程序會使用默認學習方案、但此函數應當返null。
	#See[{nameof(ExtnBoStudyPlan.FromJnStudyPlan)}]
	要帶緩存、在此接口之實現類中維護 CurBoStudyPlanCache、
	如後續再調用 {nameof(GetCurBoStudyPlan)}、先用 {nameof(GetCurStudyPlanId)}、
	若其Id與緩存之ID相同 且 {nameof(PoStudyPlan.BizUpdatedAt)} 未變 則返緩存。
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
	
	[Doc(@$"生成內置權重算法。
	內置的 {nameof(I_UniqName.UniqName)}要有前綴{nameof(Consts.BuiltinPrefix)}。
	- 默認權重算法: {nameof(DfltWeightCalculator)}
		- 名稱: 內置前綴 拼上 {nameof(DfltWeightCalculator.Name)}
	- 默認權重算法參數: {nameof(DfltWeightCfg)}
	- 默認學習方案名稱: 內置前綴 拼上 `Default`
	內置的都不需要 {nameof(PoStudyPlan.Descr)}
	")]
	public Task<BoStudyPlan> GetBuiltinStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
	[Doc(@$"確保用戶當前學習方案存在。
	當用戶未添加任何學習方案旹、
	先 調{nameof(GetBuiltinStudyPlan)}、
	再設{nameof(KeysClientKv.CurStudyPlanId)} 設爲默認權重算法的id。
	")]
	public Task<bool> EnsureCurStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
}
