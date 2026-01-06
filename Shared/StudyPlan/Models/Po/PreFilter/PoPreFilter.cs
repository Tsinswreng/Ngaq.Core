using Ngaq.Core.Model.Po;
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
	/// <summary>
	/// Dataʹ 結構ʹ版本號。如 若Data潙Json旹 斯Ver即其Json結構ʹ版本號
	/// </summary>
	public Version DataSchemaVer{get;set;} = new();
	/// <summary>
	/// u8[] 便于存 字符以外之數據
	/// </summary>
	public u8[]? Data{get;set;} = [];


}
