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
		Arg: {//若潙Cli則把Arg序列化作json後 當命令行參數傳入。若潙腳本則作Dict傳入
			AddCnt_Bonus: [0xff,0xfff,0xffff,0xfffff],
			DebuffNumerator: 36
		}
	},
	PreFilter: {
		FieldFilter: [
			{
				Field: "tag",
				Filter: {
					Include: ["grammar"],
					Exclude: [],
				}
			},
		],
		LangFilter: {
			Include: ["English"],
			Exclude: ["English"],
		},
		TimeFilter:{//暫不支持

		},
		//可能還有更多其他字段
	},
}
#endif
