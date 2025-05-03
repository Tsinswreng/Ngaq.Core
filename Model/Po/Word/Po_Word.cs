namespace Ngaq.Core.Model.Po.Word;

public class Po_Word : I_PoBase{


	#region PoBase
	public i64 CreatedAt{get;set;}
	public str? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public str? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion

/// <summary>
/// 詞形標識
/// </summary>
	public str WordFormId{get;set;}="";

}