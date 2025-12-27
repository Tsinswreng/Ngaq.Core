using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;

public class PoStudyPlan
	:PoBase
	,I_Id<IdStudyPlan>
{
	public IdStudyPlan Id{get;set;}
	public str? UniqueName{get;set;}
	public str Descr{get;set;} = "";
	public str PreFilterJson{get;set;} = "";
	public IdWeightCalculator WeightCalculatorId{get;set;}
	public IdWeightArg WeightArgId{get;set;}

}
