namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

public class PreFilter{
	public Version Version { get; set; } = new Version(1, 0, 0, 0);
	public IList<FieldsFilter> CoreFilter { get; set; } = [];
	public IList<FieldsFilter> PropFilter {get;set;} = [];
}


#if false
{
	"CoreFilter": [
		{
			"Fields": ["Lang"],//對每個元素都應用 同ʹ Filters。減ᵈ褈ʹ代碼
			"Filters": [
				{
					"ValueType": "String",
					"Operation": "IncludeAll",
					"Values": ["English"]
				},
				{
					"ValueType": "String",
					"Operation": "ExcludeAll",
					"Values": ["Japanese"]
				},
			]
		},
		{
			"Fields": ["CreatedAt"],
			"Filters": [
				{
					"ValueType": "Number",
					"Operation": "Gt",
					"Values": [1707600693739]
				}
			]
		}
	],
	"PropFilter": [
		{
			"Fields": ["tag"],
			"Filters": [
				{
					"ValueType": "String",
					"Operation": "IncludeAll",
					"Values": ["grammar"]
				}
			]
		},
		{
			"Fields": ["source"],
			"Filters": [
				{
					"ValueType": "String",
					"Operation": "IncludeAll",
					"Values": ["News", "Book"]
				}
			]
		}
	]
}
#endif


