namespace Ngaq.Core.Model.Po.Kv;

public partial class Po_Kv
	:I_PoBase
{
	#region PoBase
	public i64 CreatedAt{get;set;}
	public str? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public str? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion
	public i64 SubjectIdType { get; set; } = (i64)E_SubjectIdType.Int64;
	public Int128? SubjectId_I128{get;set;}
	public str? SubjectId_Str{get;set;}

	public i64 KType { get; set; } = (i64)E_KvType.Str;
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	public i64 KI64 { get; set; }
	//public str KeyType {get; set;} = "";

	public str? KDesc { get; set; }

	public i64 VType { get; set; }

	public str? VDesc { get; set; }

	//[Column("str")]
	public str? VStr { get; set; }
	//[Column("int")]
	public i64 VI64 { get; set; }

	public f64 VF64 { get; set; }
}