namespace Ngaq.Core.Infra.Cfg;
using Tsinswreng.CsCfg;



public partial class AppCfg: DualSrcCfg, ICfgAccessor{
	protected static AppCfg? _Inst = null;
	public static AppCfg Inst => _Inst??= new AppCfg();

}
