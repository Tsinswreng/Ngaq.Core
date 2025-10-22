namespace Ngaq.Core.Shared.Word.Models.Learn_;

public  partial interface ILearnRecord{
	/// <summary>
	/// 見ConstLearn
	/// </summary>
	public ELearn Learn{get;set;}
	public i64 UnixMs{get;set;}
}
