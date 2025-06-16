namespace Ngaq.Core.Infra.Cfg;

public class AppCfg: JsonCfgAccessor, ICfgAccessor{
	protected static AppCfg? _Inst = null;
	public static AppCfg Inst => _Inst??= new AppCfg();

}
