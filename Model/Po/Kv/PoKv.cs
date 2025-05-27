#define Impl
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Model.Po.Kv;

public partial class PoKv
	:IPoBase
	,IHasId<IdKv>
	,IPoKv
{

	public static PoKv Example{get;set;} = new PoKv();

	public IdKv Id { get; set; } = new IdKv();

	#region PoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public IdUser? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}
	public i64 Status{get;set;}
	#endregion
	public i64 FKeyType { get; set; } = (i64)E_SubjectIdType.Int64;
	public str? FKeyStr{get;set;}
	public UInt128? FKeyUInt128{get;set;}

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
