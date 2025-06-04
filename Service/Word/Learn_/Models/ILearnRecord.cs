namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface ILearnRecord{
	/// <summary>
	/// 見ConstLearn
	/// </summary>
	public Learn Learn{get;set;}
	public i64 UnixMs{get;set;}
}
