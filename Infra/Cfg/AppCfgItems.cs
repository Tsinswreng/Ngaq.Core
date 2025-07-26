using Tsinswreng.CsCfg;

namespace Ngaq.Core.Infra.Cfg;

using Tsinswreng.CsCfg;
using static ExtnCfgItem;
//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩
public  class LocalCfgItems{

#if DEBUG
	public static ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else
	public static ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.sqlite");
#endif
	public static ICfgItem<str> MergedConfigPath = Mk(null, [nameof(MergedConfigPath)], "Ngaq.Merged.jsonc");

	public static ICfgItem Background = Mk(null, [nameof(Background)], null);
		public static ICfgItem<IList<object?>> GalleryDirs = Mk(Background, [nameof(GalleryDirs)], (IList<object?>)[]);
	public static ICfgItem<str> ServerBaseUrl = Mk(null, [nameof(ServerBaseUrl)], "");
	public static ICfgItem Ui = Mk(null, [nameof(Ui)], null);
		public static ICfgItem<f64> BaseFontSize = Mk(Ui, [nameof(BaseFontSize)], 16.0);

}
