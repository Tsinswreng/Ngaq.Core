namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface I_Time_UnsavedLearnRecords{
	/// <summary>
	/// 當有序
	/// </summary>
	public IDictionary<i64, LearnRecord> Time_UnsavedLearnRecords{get;set;}
	#if Impl
	= new Dictionary<i64, LearnRecord>();
	#endif
}
