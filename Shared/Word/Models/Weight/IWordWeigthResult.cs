namespace Ngaq.Core.Word.Models.Weight;

public partial interface IWordWeightResult{
	
	/// 不用UInt128 方便序列化 更通用
	
	public str StrId{get;set;}
	public f64 Weight{get;set;}
	public u64 Index{get;set;}
}
