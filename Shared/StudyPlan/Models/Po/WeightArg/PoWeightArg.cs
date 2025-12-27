using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;

public class PoWeightArg
	:PoBase
	,I_Id<IdWeightArg>
{
	public IdWeightArg Id{get;set;}
	public str? UniqueName{get;set;}

	public EWeightArgType Type{get;set;} = EWeightArgType.Json;
	public u8[] Data{get;set;} = [];

	[See(nameof(PoWeightCalculator.UniqueName))]
	public str WeightCalculatorName{get;set;} = "";

	public str Descr{get;set;} = "";
}

