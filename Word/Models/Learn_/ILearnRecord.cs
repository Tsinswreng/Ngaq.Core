namespace Ngaq.Core.Word.Models.Learn_;

public  partial interface ILearnRecord{
	/// <summary>
	/// 見ConstLearn
	/// </summary>
	public Learn Learn{get;set;}
	public i64 UnixMs{get;set;}
}
