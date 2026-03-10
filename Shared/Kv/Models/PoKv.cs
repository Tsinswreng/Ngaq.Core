namespace Ngaq.Core.Shared.Kv.Models;

using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Infra;
using Ngaq.Core.Sys.Models;
using Tsinswreng.CsFactoryMkr;
using Ngaq.Core.Infra.IF;

[MkFactory(For=typeof(PoKv))]
public partial class PoKv
	:PoBase
	,I_IdOld<IdKv>
	,IPoKv
{

	[Impl(typeof(I_IdOld<IdKv>))]
	public IdKv Id{get;set;} = new();

	public IdUser Owner{get;set;} = IdUser.Zero;

	#region IPoKv
	[Impl(typeof(IPoKv))]
	public EKvType KType { get; set; } = EKvType.Str;
	[Impl(typeof(IPoKv))]
	public str? KStr { get; set; } = null;
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	[Impl(typeof(IPoKv))]
	public i64 KI64 { get; set; } = 0;

	[Impl(typeof(IPoKv))]
	public EKvType VType { get; set; } = EKvType.Str;

	[Impl(typeof(IPoKv))]
	public str? VStr { get; set; } = null;
	[Impl(typeof(IPoKv))]
	public i64 VI64 { get; set; } = 0;
	[Impl(typeof(IPoKv))]
	public f64 VF64 { get; set; } = 0.0;
	public u8[]? VBinary {get;set;} = null;
	#endregion IPoKv
}
