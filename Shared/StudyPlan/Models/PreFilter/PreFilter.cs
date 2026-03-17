using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;

namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;

[Doc(@$"業務模型
與{nameof(PoPreFilter)}之區別:
Po 是 數據庫實體、其成員 要考慮 與數據庫列 的對應;
此爲 業務模型、 不考慮如何儲存、 只考慮在代碼內存中的抽象
")]
public class PreFilter{
	[Doc($@"篩選配置結構版本")]
	public Version Version { get; set; } = new Version(1, 0, 0, 0);
	[Doc($@"核心字段篩選條件組")]
	public IList<FieldsFilter> CoreFilter { get; set; } = [];
	[Doc($@"擴展屬性篩選條件組")]
	public IList<FieldsFilter> PropFilter {get;set;} = [];
}


#if false
{
	"CoreFilter": [
		{
			"Fields": ["Lang"],//對每個元素都應用 同ʹ Filters。減ᵈ褈ʹ代碼
			"Filters": [ // 多個filter間是 「且」 關係
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


