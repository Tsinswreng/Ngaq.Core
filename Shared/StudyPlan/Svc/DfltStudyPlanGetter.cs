using Ngaq.Core.Shared.StudyPlan.Models;
using Ngaq.Core.Shared.Word.WeightAlgo;

namespace Ngaq.Core.Shared.StudyPlan.Svc;

public class DfltStudyPlanGetter:IStudyPlanGetter{
	public Task<BoStudyPlan> GetStudyPlan(CT Ct){
		return Task.FromResult(new BoStudyPlan{
			WeightCalctr = new DfltWeightCalculator(),
			WeightArg = new Dictionary<str, obj>(),
		});
	}
}
