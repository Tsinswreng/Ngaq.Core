namespace Ngaq.Core.Infra.Cfg;
using static ExtnCfgItem;
//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩
public class LocalCfgItems{
	protected static LocalCfgItems? _Inst = null;
	public static LocalCfgItems Inst => _Inst??= new LocalCfgItems();




#if DEBUG
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.sqlite");
#endif

	public ICfgItem Background = Mk([nameof(Background)], null);

	public ICfgItem<IList<object?>> GalleryDirs = Mk([nameof(Background), nameof(GalleryDirs)], (IList<object?>)[]);

}
