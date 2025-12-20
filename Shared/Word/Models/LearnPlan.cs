namespace Ngaq.Core.Shared.Word.Models;

using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Svc;


public struct IdStudyPlan{

}


public class FilterInExClude<T>{
	public ISet<T> Include{get;set;}
	public ISet<T> Exclude{get;set;}
}

public class FieldWithFilter<T>{
	/// <summary>
	/// 如 Lang, Tag ...
	/// </summary>
	public str Field{get;set;}
	public FilterInExClude<T> Filter{get;set;}
}

public class PreFilter{
	public IList<FieldWithFilter<str>> Fields{get;set;}
}
//TODO 按時間, 各事件ʹ次 等

public class StudyPlan{
	public IdStudyPlan Id{get;set;}
	// public IList<str> LangIncluded{get;set;}
	// public IList<str> LangExcluded{get;set;}
	public str UniqueName{get;set;}
	public str Descr{get;set;}
	public IWeightCalctr WeightCalctr{get;set;}
	public IKvNode CfgWeightCalctr{get;set;}
}
