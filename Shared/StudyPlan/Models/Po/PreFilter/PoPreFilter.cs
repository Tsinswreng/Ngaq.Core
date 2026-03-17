using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;

[Doc($@"學習方案前置篩選器持久化實體")]
public class PoPreFilter
	:PoBaseBizTime
	,AppI_Id<IdPreFilter>
	,I_Owner
{
	[Doc($@"主鍵")]
	public IdPreFilter Id{get;set;} = new();
	[Doc($@"擁有者")]
	public IdUser Owner{get;set;} = IdUser.Zero;
	[Doc($@"用戶側唯一名")]
	public str? UniqName{get;set;} = null;
	[Doc($@"描述")]
	public str Descr{get;set;} = "";
	[Doc($@"數據格式類型")]
	public EPreFilterType Type{get;set;}
	[Doc($@"{nameof(Data)} 的結構版本")]
	/// Dataʹ 結構ʹ版本號。如 若Data潙Json旹 斯Ver即其Json結構ʹ版本號
	public Version DataSchemaVer{get;set;} = new();
	[Doc($@"篩選器二進制載荷")]
	/// u8[] 便于存 字符以外之數據
	/// 後續可能支持 腳本/可執行文件/程序 形式之prefilter
	public u8[]? Data{get;set;} = [];


}
