using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Po.Kv;

namespace Ngaq.Core.Sys.Models;

public class PoCfg
	:PoBase
	,I_Id<IdCfg>
	,IPoKv
	,I_BizTimeVer
{

	[Impl(typeof(I_Id<IdCfg>))]
	public IdCfg Id{get;set;}

	public IdUser Owner{get;set;}


	[Impl(typeof(I_BizTimeVer))]
	public Tempus BizTimeVer{get;set;}
	#region IPoKv
	[Impl(typeof(IPoKv))]
	public i64 KType { get; set; }
	[Impl(typeof(IPoKv))]
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	[Impl(typeof(IPoKv))]
	public i64 KI64 { get; set; }
	[Impl(typeof(IPoKv))]
	public str? KDescr { get; set; }
	[Impl(typeof(IPoKv))]
	public i64 VType { get; set; }
	[Impl(typeof(IPoKv))]
	public str? VDescr { get; set; }
	[Impl(typeof(IPoKv))]
	public str? VStr { get; set; }
	[Impl(typeof(IPoKv))]
	public i64 VI64 { get; set; }
	[Impl(typeof(IPoKv))]
	public f64 VF64 { get; set; }
	#endregion IPoKv
}
