using Tsinswreng.CsCfg;

namespace Ngaq.Core.Infra.Cfg;

public partial class LocalCfg: DualSrcCfg, ICfgAccessor{
	protected static LocalCfg? _Inst = null;
	public static LocalCfg Inst => _Inst??= new LocalCfg();

}
