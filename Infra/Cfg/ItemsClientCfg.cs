namespace Ngaq.Core.Infra.Cfg;

using System.Collections;
using Tsinswreng.CsCfg;
using static Tsinswreng.CsCfg.CfgItem<obj?>;
//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩

public class ItemsClientCfg{
	public static ICfgItem<str> Lang = Mk(null, [nameof(Lang)], "default");

#if DEBUG&&false
	public static ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else

	public static ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.sqlite");
#endif
	public static ICfgItem<str> RwCfgPath = Mk(null, [nameof(RwCfgPath)], "Ngaq.Rw.jsonc");

	public class Background{
		public static ICfgItem _R = Mk(null, [nameof(Background)]);
		//[EnumOf("")]
		public static ICfgItem<str> Mode = Mk(_R, [nameof(Mode)], "");
		public static ICfgItem<IList<object?>> GalleryDirs = Mk(_R, [nameof(GalleryDirs)], (IList<object?>)[]);
	}

	// public static ICfgItem Background = Mk(null, [nameof(Background)], null);
	// 	public static ICfgItem<IList<object?>> GalleryDirs = Mk(Background, [nameof(GalleryDirs)], (IList<object?>)[]);
	public static ICfgItem<str> ServerBaseUrl = Mk(null, [nameof(ServerBaseUrl)], "");
	public static ICfgItem Ui = Mk(null, [nameof(Ui)], null);
		public static ICfgItem<f64> BaseFontSize = Mk(Ui, [nameof(BaseFontSize)], 16.0);

	public static ICfgItem User = Mk(null, [nameof(User)], null);
		public static ICfgItem<str> CurrentUserId = Mk(User, [nameof(CurrentUserId)], "0");

	public class Word{
		public static ICfgItem _R = Mk(null, [nameof(Word)]);
		public static ICfgItem<str> WordsPackExportPath = Mk(_R, [nameof(WordsPackExportPath)], "");
		public static ICfgItem<str> WordsPackImportPath = Mk(_R, [nameof(WordsPackImportPath)], "");
		public static ICfgItem<u64> MaxDisplayedWordCount = Mk(_R, [nameof(MaxDisplayedWordCount)], 50ul);
		public static ICfgItem<IList<obj?>?> FilterLanguage = Mk(_R, [nameof(FilterLanguage)], (IList<obj?>)null);
		public static ICfgItem<bool> EnableRandomBackground = Mk(_R, [nameof(EnableRandomBackground)], false);
	}

}

