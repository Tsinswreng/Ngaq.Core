namespace Ngaq.Core.Word.Models.Po.Kv;
using Ngaq.Core.Infra.IF;



public partial interface IPoKv:IAppSerializable{
	#region IPoKv
	public i64 KType { get; set; }
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	public i64 KI64 { get; set; }
	public str? KDescr { get; set; }
	public i64 VType { get; set; }

	public str? VDescr { get; set; }
	public str? VStr { get; set; }
	public i64 VI64 { get; set; }
	public f64 VF64 { get; set; }
	#endregion IPoKv
}
