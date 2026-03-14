using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Shared.StudyPlan.Models;

public class JnStudyPlan{
	public PoStudyPlan StudyPlan{get;set;}
	public PoPreFilter? PreFilter{get;set;} = null;
	public PoWeightCalculator? WeightCalculator{get;set;} = null;
	public PoWeightArg? WeightArg{get;set;} = null;
}

public class BoStudyPlan{
	
	public PoStudyPlan? PoStudyPlan{get;set;} = null;
	/// 數據庫實體
	public PoPreFilter? PoPreFilter{get;set;} = null;
	/// 業務模型
	public PreFilter.PreFilter? PreFilter{get;set;} = null;

	public PoWeightCalculator? PoWeightCalculator{get;set;} = null;
	public IWeightCalctr? WeightCalctr{get;set;} = null;

	public PoWeightArg? PoWeightArg{get;set;} = null;

	public IJsonNode? WeightArg{get;set;} = null;

}


