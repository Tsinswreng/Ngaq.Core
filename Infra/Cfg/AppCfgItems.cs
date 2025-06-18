namespace Ngaq.Core.Infra.Cfg;

//TODO 異常處理 勿緣用戶配置ʹ謬而致整程序崩
public class AppCfgItems{
	protected static AppCfgItems? _Inst = null;
	public static AppCfgItems Inst => _Inst??= new AppCfgItems();

	public static ICfgItem<object?> Mk(IList<str> Path, ICfgValue? DfltValue = null){
		return new CfgItem<object?>{Path=Path, DfltValue=DfltValue};
	}
/// <summary>
/// 如需列表則需定義潙IList<object> 不支持IList<str>等!
/// </summary>
/// <typeparam name="T2"></typeparam>
/// <param name="Path"></param>
/// <param name="DfltValue"></param>
/// <returns></returns>
	public static ICfgItem<T2> Mk<T2>(IList<str> Path, T2 DfltValue = default!){
		var V = new CfgValue(){Type=typeof(T2), Data=DfltValue};
		return new CfgItem<T2>{Path=Path, DfltValue=V};
	}


#if DEBUG
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.dev.sqlite");
#else
	public ICfgItem<str> SqlitePath = Mk([nameof(SqlitePath)], "./Ngaq.sqlite");
#endif

	public ICfgItem Background = Mk([nameof(Background)], null);

	public ICfgItem<IList<object?>> GalleryDirs = Mk([nameof(Background), nameof(GalleryDirs)], (IList<object?>)[]);

}
