using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;

[Doc($@"學習方案持久化實體")]
public class PoStudyPlan
	:PoBaseBizTime
	,AppI_Id<IdStudyPlan>
	,I_Owner
{
	[Doc($@"主鍵")]
	public IdStudyPlan Id{get;set;} = new();
	[Doc($@"擁有者")]
	public IdUser Owner{get;set;} = IdUser.Zero;
	[Doc($@"用戶側唯一名")]
	public str? UniqueName{get;set;} = null;
	[Doc($@"描述")]
	public str Descr{get;set;} = "";
	[Doc($@"關聯的前置篩選器ID")]
	public IdPreFilter PreFilterId{get;set;} = IdPreFilter.Zero;
	[Doc($@"關聯的權重算法ID")]
	public IdWeightCalculator WeightCalculatorId{get;set;} = IdWeightCalculator.Zero;
	[Doc($@"關聯的權重參數ID")]
	public IdWeightArg WeightArgId{get;set;} = IdWeightArg.Zero;

}
