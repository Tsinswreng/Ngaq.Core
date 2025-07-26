namespace Ngaq.Core.Model.Po.Kv;

public  partial interface IPoKv{

	#region IPoKv
	//TODO 遷至他ʹ接口
	// public i64 FKeyType { get; set; } //`= (i64)E_SubjectIdType.Int64;
	// public UInt128? FKeyUInt128{get;set;}
	// public str? FKeyStr{get;set;}

	public i64 KType { get; set; }
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
	#endregion IPoKv
}
