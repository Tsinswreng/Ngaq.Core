namespace Ngaq.Core.Infra.Cfg;

public interface ICfgItem{
	public IList<str> Path{get;set;}
	public ICfgValue? DfltValue{get;set;}
}

public interface ICfgItem<T>:ICfgItem{

}

public class CfgItem<T>:ICfgItem<T>{
	public CfgItem(){

	}
	public IList<str> Path{get;set;} = [];
	public ICfgValue? DfltValue{get;set;}
}

public static class ExtnCfgItem{

	public static T? Get<T>(
		this ICfgItem<T> Item
		,ICfgAccessor? CfgAccessor = null
	)where T: class{
		CfgAccessor ??= AppCfg.Inst;
		var Got = CfgAccessor.GetByPath(Item.Path);
		if(Got == null){
			return Item.DfltValue as T;
		}
		if (Got.Data == null){
			return null;
		}
		if(Got.Data is not T R){
			throw new ArgumentException("Got.Data is not T");
		}
		return R;
	}

	// public static T? Get<T>(
	// 	this ICfgItem Item
	// 	,ICfgAccessor? CfgAccessor = null
	// )where T: class{
	// 	CfgAccessor ??= AppCfg.Inst;
	// 	var Got = CfgAccessor.GetByPath(Item.Path);
	// 	if(Got == null){
	// 		return null;
	// 	}
	// 	return Got.Data as T;
	// }
}


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
