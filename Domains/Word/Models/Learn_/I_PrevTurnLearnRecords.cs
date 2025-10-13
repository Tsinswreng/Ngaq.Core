namespace Ngaq.Core.Word.Models.Learn_;

/// <summary>
/// 上輪學習記錄
/// 供權重算法用 如 無上輪學習記錄者視潙未學 則不緟算權重
/// </summary>
public  partial interface I_PrevTurnLearnRecords{
	/// <summary>
	/// 上輪學習記錄
	/// 供權重算法用 如 無上輪學習記錄者視潙未學 則不緟算權重
	/// </summary>
	public IList<ILearnRecord> PrevTurnLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif
}
