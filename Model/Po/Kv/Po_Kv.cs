#define Impl
namespace Ngaq.Core.Model.Po.Kv;

public partial class Po_Kv
	:I_PoBase
	,I_Id<Id_Kv>
	,I_Po_Kv
{

	public Id_Kv Id { get; set; }

	#region PoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public str? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public str? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion
	public i64 SubjectIdType { get; set; } = (i64)E_SubjectIdType.Int64;
	public str? SubjectId_Str{get;set;}
	public UInt128? SubjectId_UInt128{get;set;}

	public i64 KType { get; set; } = (i64)E_KvType.Str;
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	public i64 KI64 { get; set; }
	//public str KeyType {get; set;} = "";

	public str? KDescr { get; set; }

	public i64 VType { get; set; }

	public str? VDescr { get; set; }

	//[Column("str")]
	public str? VStr { get; set; }
	//[Column("int")]
	public i64 VI64 { get; set; }

	public f64 VF64 { get; set; }
}
