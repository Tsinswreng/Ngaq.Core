namespace Ngaq.Core.Word.Models.Learn_;

public  partial interface I_LearnRecords{
	/// <summary>
	/// 已保存之學習記錄
	/// 當有序
	/// </summary>
	public IList<ILearnRecord> LearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif
}
