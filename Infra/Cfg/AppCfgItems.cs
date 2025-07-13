using Tsinswreng.CsCfg;

namespace Ngaq.Core.Infra.Cfg;

using Tsinswreng.CsCfg;
using static ExtnCfgItem;
//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩
public class LocalCfgItems{
	protected static LocalCfgItems? _Inst = null;
	public static LocalCfgItems Inst => _Inst??= new LocalCfgItems();

#if DEBUG
	public ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else
	public ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.sqlite");
#endif

	public ICfgItem Background = Mk(null, [nameof(Background)], null);
		public ICfgItem<IList<object?>> GalleryDirs => Mk(Background, [nameof(GalleryDirs)], (IList<object?>)[]);
	public ICfgItem<str> ServerBaseUrl = Mk(null, [nameof(ServerBaseUrl)], "");

}
