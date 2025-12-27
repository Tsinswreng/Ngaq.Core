
using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;


public class PoWeightCalculator
	:PoBase
	,I_Id<IdWeightCalculator>
{
	public IdWeightCalculator Id{get;set;}
	public str? UniqueName{get;set;}
	public EWeightCalculatorType Type{get;set;}
	//public str ArgJson{get;set;} = "";
	public str Data{get;set;} = "";
	public str Descr{get;set;} = "";
}

