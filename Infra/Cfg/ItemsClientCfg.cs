namespace Ngaq.Core.Infra.Cfg;

using System.Collections;
using Tsinswreng.CsCfg;
using static Tsinswreng.CsCfg.CfgNode<obj?>;
//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩

public class ItemsClientCfg{
	public static ICfgNode<str> Lang = Mk(null, [nameof(Lang)], "default");

#if DEBUG&&false
	public static ICfgItem<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else

	public static ICfgNode<str> SqlitePath = Mk(null, [nameof(SqlitePath)], "./Ngaq.sqlite");
#endif
	public static ICfgNode<str> RwCfgPath = Mk(null, [nameof(RwCfgPath)], "Ngaq.Rw.jsonc");

	public class Background{
		public static ICfgNode _R = Mk(null, [nameof(Background)]);
		//[EnumOf("")]
		public static ICfgNode<str> Mode = Mk(_R, [nameof(Mode)], "");
		public static ICfgNode<IList<object?>> GalleryDirs = Mk(_R, [nameof(GalleryDirs)], (IList<object?>)[]);
	}

	// public static ICfgItem Background = Mk(null, [nameof(Background)], null);
	// 	public static ICfgItem<IList<object?>> GalleryDirs = Mk(Background, [nameof(GalleryDirs)], (IList<object?>)[]);
	public static ICfgNode<str> ServerBaseUrl = Mk(null, [nameof(ServerBaseUrl)], "");
	public static ICfgNode Ui = Mk(null, [nameof(Ui)], null);
		public static ICfgNode<f64> BaseFontSize = Mk(Ui, [nameof(BaseFontSize)], 16.0);

	public static ICfgNode User = Mk(null, [nameof(User)], null);
		public static ICfgNode<str> CurrentUserId = Mk(User, [nameof(CurrentUserId)], "0");

	public class Word{
		public static ICfgNode _R = Mk(null, [nameof(Word)]);
		public static ICfgNode<str> WordsPackExportPath = Mk(_R, [nameof(WordsPackExportPath)], "");
		public static ICfgNode<str> WordsPackImportPath = Mk(_R, [nameof(WordsPackImportPath)], "");
		public static ICfgNode<u64> MaxDisplayedWordCount = Mk(_R, [nameof(MaxDisplayedWordCount)], 500ul);
		[Obsolete]
		public static ICfgNode<IList<obj?>?> FilterLanguage = Mk(_R, [nameof(FilterLanguage)], (IList<obj?>?)null);
		public static ICfgNode<bool> EnableRandomBackground = Mk(_R, [nameof(EnableRandomBackground)], false);
		[Doc("背單詞旹 點擊單詞後是否自動發音")]
		public static ICfgNode<bool> EnableAutoPronounce = Mk(_R, [nameof(EnableAutoPronounce)], false);
	}

	public class LlmDictionary{
		public static ICfgNode _R = Mk(null, [nameof(LlmDictionary)]);
		public static ICfgNode<str> ApiUrl = Mk(_R, [nameof(ApiUrl)], "");
		public static ICfgNode<str> ApiKey = Mk(_R, [nameof(ApiKey)], "");
		public static ICfgNode<str> Model = Mk(_R, [nameof(Model)], "");
	}
}

