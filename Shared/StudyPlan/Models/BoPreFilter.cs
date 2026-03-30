using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

namespace Ngaq.Core.Shared.StudyPlan.Models;

public class BoPreFilter{
	public PoPreFilter PoPreFilter { get; set; }
	public PreFilter.PreFilter PreFilter{get;set;}
	
	[Doc(@$"原地賦值 要初始化 {nameof(PoPreFilter)} 和 {nameof(PreFilter)}.
	#See[{nameof(ExtnPreFilter.FromPo)}]
	")]
	public void FromPoPreFilter(PoPreFilter PoPreFilter){
		throw new NotImplementedException();
	}
}
