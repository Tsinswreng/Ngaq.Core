namespace Ngaq.Core.Model.Po;
public interface I_PoBase{
	#region PoBase
	public i64 CreatedAt{get;set;}
	public str? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public str? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion
}