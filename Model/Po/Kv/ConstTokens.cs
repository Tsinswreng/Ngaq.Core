namespace Ngaq.Core.Model.Po.Kv;

public class ConstTokens{
	protected static ConstTokens? _Inst = null;
	public static ConstTokens Inst => _Inst??= new ConstTokens();

	/// <summary>
	/// 命名空間與名 之分隔符
	/// 適用于Const_PropKey及Const_Learn等
	/// 內置鍵名等皆在頂級命名空間下 如":annotation", ":tag"等 勿省`:`
	/// 用戶自定義鍵名則在用戶命名空間下 如"Tsinswreng:Annotation"
	/// </summary>
	public str SepNamespaceEtName = ":";
	public str Concat(str? ns, str name){
		ns = ns??"";
		if(ns == ""){
			return name;
		}
		return ns + SepNamespaceEtName + name;
	}

}

public static class ExtnIPoKv{
	public static IPoKv SetStrToken(
		this IPoKv z
		,str? ns
		,str name
		,str value
	){
		var T = ConstTokens.Inst;
		var key = T.Concat(ns, name);
		z.SetStr(key, value);
		return z;
	}

	// public static str GetStrToken(
	// 	this IPoKv z
	// 	,str? ns
	// 	,str name
	// ){
	// 	var T = ConstTokens.Inst;
	// 	var key = T.Concat(ns, name);
	// 	//return z.GetStr(key);
	// }
}


// public class Const_Tokens{
// 	/// <summary>
// 	/// 命名空間與名 之分隔符
// 	/// 適用于Const_PropKey及Const_Learn等
// 	/// 內置鍵名等皆在頂級命名空間下 如":annotation", ":tag"等
// 	/// 用戶自定義鍵名則在用戶命名空間下 如"Tsinswreng:Annotation"
// 	/// </summary>
// 	public const str Sep_NamespaceEtName = ":";
// 	public static str Concat(str? ns, str name){
// 		ns = ns??"";
// 		return ns + Sep_NamespaceEtName + name;
// 	}
// }
