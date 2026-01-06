namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

public class FieldsFilter{
	public IList<str> Fields{get;set;} = [];
	public IList<FilterItem> Filters{get;set;} = [];
}
