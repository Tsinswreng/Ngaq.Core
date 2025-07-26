namespace Ngaq.Core.Word.Models.Weight;

public  partial interface IWordWeightResult{
	/// <summary>
	/// 不用UInt128 方便序列化
	/// </summary>
	public string StrId{get;set;}
	public f64 Weight{get;set;}
	public u64 Index{get;set;}
}
