namespace Ngaq.Core.Domains.Kv.Models;

using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Domains.Word.Models.Po.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Sys.Models;

public class PoKv
	:PoBase
	,I_Id<IdKv>
	,IPoKv
{

	[Impl(typeof(I_Id<IdKv>))]
	public IdKv Id{get;set;} = new();

	public IdUser Owner{get;set;} = default(IdUser);

	#region IPoKv
	[Impl(typeof(IPoKv))]
	public EKvType KType { get; set; }
	[Impl(typeof(IPoKv))]
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	[Impl(typeof(IPoKv))]
	public i64 KI64 { get; set; }

	[Impl(typeof(IPoKv))]
	public EKvType VType { get; set; }

	[Impl(typeof(IPoKv))]
	public str? VStr { get; set; }
	[Impl(typeof(IPoKv))]
	public i64 VI64 { get; set; }
	[Impl(typeof(IPoKv))]
	public f64 VF64 { get; set; }
	public u8[]? VBinary {get;set;}
	#endregion IPoKv
}
