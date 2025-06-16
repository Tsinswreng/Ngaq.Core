namespace Ngaq.Core.Infra.Cfg;
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
