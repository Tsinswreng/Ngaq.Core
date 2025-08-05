using Tsinswreng.CsCfg;

namespace Ngaq.Core.Infra.Cfg;

public partial class AppCfg: DualSrcCfg, ICfgAccessor{
	protected static AppCfg? _Inst = null;
	public static AppCfg Inst => _Inst??= new AppCfg();

}
