namespace Ngaq.Core.Infra.Cfg;

public class AppCfgItems{
	protected static AppCfgItems? _Inst = null;
	public static AppCfgItems Inst => _Inst??= new AppCfgItems();

	public static ICfgItem<object?> Mk(IList<str> Path, ICfgValue? DfltValue = null){
		return new CfgItem<object?>{Path=Path, DfltValue=DfltValue};
	}
	public static ICfgItem<T2> Mk<T2>(IList<str> Path, T2 DfltValue = default!){
		var V = new CfgValue(){Type=typeof(T2), Data=DfltValue};
		return new CfgItem<T2>{Path=Path, DfltValue=V};
	}


#if DEBUG
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.sqlite");
#endif

	public ICfgItem<str> GalleryDir = Mk([nameof(GalleryDir)], "");

}
