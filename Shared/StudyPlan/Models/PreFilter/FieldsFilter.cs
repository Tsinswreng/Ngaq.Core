namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

[Doc($@"字段集合對應的篩選條件集合")]
public class FieldsFilter{
	[Doc($@"要應用篩選的字段名列表")]
	public IList<str> Fields{get;set;} = [];
	[Doc($@"針對字段列表的條件列表")]
	public IList<FilterItem> Filters{get;set;} = [];
}
