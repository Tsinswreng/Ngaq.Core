using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;

public class PoStudyPlan
	:PoBaseBizTime
	,I_Id<IdStudyPlan>
	,I_Owner
{
	public IdStudyPlan Id{get;set;} = new();
	public IdUser Owner{get;set;} = IdUser.Zero;
	public str? UniqueName{get;set;} = null;
	public str Descr{get;set;} = "";
	public IdPreFilter PreFilterId{get;set;} = IdPreFilter.Zero;
	public IdWeightCalculator WeightCalculatorId{get;set;} = IdWeightCalculator.Zero;
	public IdWeightArg WeightArgId{get;set;} = IdWeightArg.Zero;

}
