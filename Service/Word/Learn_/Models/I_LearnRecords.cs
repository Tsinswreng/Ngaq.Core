namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface I_LearnRecords{
	/// <summary>
	/// 當有序
	/// </summary>
	public IList<ILearnRecord> LearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif
}
