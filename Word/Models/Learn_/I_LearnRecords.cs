namespace Ngaq.Core.Word.Models.Learn_;

public interface I_SavedLearnRecords{
	/// <summary>
	/// 已保存之學習記錄
	/// 當有序
	/// </summary>
	public IList<ILearnRecord> SavedLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif
}
