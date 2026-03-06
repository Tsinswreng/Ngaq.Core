using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;

public class PoPreFilter
	:PoBaseBizTime
	,I_Id<IdPreFilter>
{
	public IdPreFilter Id{get;set;} = new();
	public str? UniqueName{get;set;} = null;
	public str Descr{get;set;} = "";
	public EPreFilterType Type{get;set;}
	/// Dataʹ 結構ʹ版本號。如 若Data潙Json旹 斯Ver即其Json結構ʹ版本號
	public Version DataSchemaVer{get;set;} = new();
	/// u8[] 便于存 字符以外之數據
	/// 後續可能支持 腳本/可執行文件/程序 形式之prefilter
	public u8[]? Data{get;set;} = [];


}
