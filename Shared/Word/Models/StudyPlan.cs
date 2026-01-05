//只是草稿
namespace Ngaq.Core.Shared.Word.Models;

using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsTools;

public struct IdStudyPlan{

}

public class FilterInExClude<T>{
	public ISet<T> Include{get;set;}
	public ISet<T> Exclude{get;set;}
}

public class FieldWithFilter<T>{
	/// <summary>
	/// WordProp中ʹKStr
	/// </summary>
	public str Field{get;set;}
	public FilterInExClude<T> Filter{get;set;}
}

/// <summary>
/// 宜作用于 從數據庫取詞旹、即拼條件于sql中。故不適 用腳本過濾表達式㕥叶㞢
/// </summary>
public class PreFilter{
	public IList<FieldWithFilter<str>> FieldFilter{get;set;}
}
//TODO 按時間, 各事件ʹ次 等

public class StudyPlan{
	public IdStudyPlan Id{get;set;}
	// public IList<str> LangIncluded{get;set;}
	// public IList<str> LangExcluded{get;set;}
	public str UniqueName{get;set;}
	public str Descr{get;set;}
	// public IWeightCalctr WeightCalctr{get;set;}
	// public IKvNode CfgWeightCalctr{get;set;}
}

public enum EWeightCalctrType{
	Cli,
	Dll,//不支持
	Js,
}

public class CfgWeight{
	public IWeightCalctr WeightCalctr{get;set;}
	public EWeightCalctrType Type{get;set;}
	public IKvNode Arg{get;set;}
}


#if false
{
	Id: "",
	UniqueName: "EnglishDefault",
	Descr: "",
	WeightCalctr: {
		Type: "Cli",
		Content: "./NgaqWeight.exe",
		Arg: {
			AddCnt_Bonus: [0xff,0xfff,0xffff,0xfffff],
			DebuffNumerator: 36
		}
	},
	PreFilter: {

	},
}

{
	"CoreFilter": {
		{
			"Fields": ["Lang"],
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
		}
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
	},
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


public enum EFilterOperationMode{
	Null=0,
	IncludeAny,
	IncludeAll,
	ExcludeAll,
	/// >
	Gt,
	/// >=
	Ge,
	/// <
	Lt,
	/// <=
	Le,
	/// =
	Eq,
	/// !=
	Ne,
}

public enum EValueType{
	Null=0,
	String,
	Number,
	//TimeUnixMs,
}

public class FilterItem{
	public EFilterOperationMode Operation{get;set;}
	public EValueType ValueType{get;set;}
	public IList<str> Values{get;set;} = [];
}
