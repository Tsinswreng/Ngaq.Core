using Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
public class FilterItem{
	public EFilterOperationMode Operation{get;set;}
	public EValueType ValueType{get;set;}
	public IList<obj?> Values{get;set;} = [];
}
