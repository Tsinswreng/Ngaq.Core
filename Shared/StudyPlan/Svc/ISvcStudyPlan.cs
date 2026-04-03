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
using Ngaq.Core.Infra.Errors;

namespace Ngaq.Core.Shared.StudyPlan.Svc;

[Doc(@$"
名詞辯析:
- 內置: 即內置、可能有多套
- 默認: 只能有一套。默認的一定是內置的、內置的不一定是默認的

- 涉及刪改的、要先去數據庫裏按Id把實體查出來、比較Owner是否一致。若不一致則拋異常。

- 涉及新增的、如已有的 ({nameof(I_Owner)},{nameof(I_UniqName)}) 與新增的沖突、
	則應拋出 {nameof(ItemsErr.StudyPlan.AddFailedDataMayConflict)}。
	若是修改則 {nameof(ItemsErr.StudyPlan.UpdateFailedDataMayConflict)}。

若操作的實體 不屬于該用戶則拋異常 {nameof(ItemsErr.Common.PermissionDenied)}
")]
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
	
	
	public IAsyncEnumerable<PoWeightCalculator?> BatGetWeightCalculatorById(
		IDbUserCtx Ctx, IAsyncEnumerable<IdWeightCalculator> Ids, CT Ct
	);
	
	public IAsyncEnumerable<PoPreFilter?> BatGetPreFilterById(
		IDbUserCtx Ctx, IAsyncEnumerable<IdPreFilter> Ids, CT Ct
	);
	
	public IAsyncEnumerable<PoWeightArg?> BatGetWeightArgById(
		IDbUserCtx Ctx, IAsyncEnumerable<IdWeightArg> Ids, CT Ct
	);
	

	public Task<nil> BatAddPreFilter(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoPreFilter> Pos
		,CT Ct
	);
	public Task<nil> BatAddStudyPlan(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoStudyPlan> Pos
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
	
	public Task<nil> BatUpdPreFilter(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoPreFilter> Pos
		,CT Ct
	);
	
	public Task<nil> BatUpdWeightCalculator(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightCalculator> Pos
		,CT Ct
	);
	
	public Task<nil> BatUpdWeightArg(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightArg> Pos
		,CT Ct
	);
	
	
	public Task<nil> BatSoftDelPreFilter(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoPreFilter> Pos
		,CT Ct
	);
	
	public Task<nil> BatSoftDelWeightCalculator(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightCalculator> Pos
		,CT Ct
	);
	
	public Task<nil> BatSoftDelWeightArg(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoWeightArg> Pos
		,CT Ct
	);
	
	public Task<nil> BatUpdStudyPlan(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoStudyPlan> Pos
		,CT Ct
	);
	
	[Doc(@$"只把Po.Id對應之{nameof(PoStudyPlan)}標記爲軟刪除、
	不要動其關聯的資產實體
	")]
	public Task<nil> BatSoftDelStudyPlan(
		IDbUserCtx Ctx
		,IAsyncEnumerable<PoStudyPlan> Pos
		,CT Ct
	);
	
	
	[Doc(@$"生成內置權重算法。
	不操作數據庫。
	內置的 {nameof(I_UniqName.UniqName)}要有前綴{nameof(Consts.BuiltinPrefix)}。
	- 默認權重算法: {nameof(DfltWeightCalculator)}
		- 名稱: 內置前綴 拼上 {nameof(DfltWeightCalculator.Name)}
	- 默認權重算法參數: {nameof(DfltWeightCfg)}
	- 默認學習方案名稱: 內置前綴 拼上 `Default`
	內置的都不需要 {nameof(PoStudyPlan.Descr)}
	")]
	public Task<BoStudyPlan> GetDfltStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
	[Doc(@$"確保用戶當前學習方案存在。
	當用戶未添加任何學習方案旹、
	先 調{nameof(GetDfltStudyPlan)}、再寫入數據庫庫、
	再{nameof(KeysClientKv.CurStudyPlanId)} 設爲默認權重算法的id。
	")]
	public Task<bool> EnsureCurStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
	[Doc(@$"把內置學習方案恢復回數據庫。
	初始情況下、數據庫中應該有內置學習方案。
	但是用戶可能原地更改內置學習方案、如改值 等。
	此函數用於恢復內置學習方案、把程序中定義的內置學習方案 原樣寫回數據庫中、
	確保{nameof(I_UniqName.UniqName)}相同的實體、除Id與時間不同之外 其他字段皆一致。
	若有衝突 則把舊值軟刪除。
	")]
	public Task<nil> RestoreBuiltinStudyPlan(
		IDbUserCtx Ctx, CT Ct
	);
	
}
