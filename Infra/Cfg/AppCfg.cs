using Tsinswreng.CsCfg;

namespace Ngaq.Core.Infra.Cfg;

public class LocalCfg: JsonCfgAccessor, ICfgAccessor{
	protected static LocalCfg? _Inst = null;
	public static LocalCfg Inst => _Inst??= new LocalCfg();

}
