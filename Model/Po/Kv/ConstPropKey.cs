namespace Ngaq.Core.Model.Po.Kv;


public struct EItemProp(str V){
	public str Value{get;set;} = V;
	public static implicit operator str(EItemProp e){
		return e.Value;
	}
	public static implicit operator EItemProp(str s){
		return new EItemProp(s);
	}
	public str Concat(str? ns, str name){
		return ConstTokens.Inst.Concat(ns, name);
	}
}


/// <summary>
/// 內置單詞屬性鍵
/// </summary>
public class KeysProp{
	protected static KeysProp? _Inst = null;
	public static KeysProp Inst => _Inst??= new KeysProp();

	public EItemProp summary = nameof(summary);
	public EItemProp description = nameof(description);
	//public StrEnum learn = nameof(learn);
	public EItemProp note = nameof(note);
	public EItemProp tag = nameof(tag);
	public EItemProp source = nameof(source);
	public EItemProp alias = nameof(alias);
	public EItemProp pronunciation = nameof(pronunciation);
	public EItemProp weight = nameof(weight);
	public EItemProp learn = nameof(learn);

}



/// <summary>
/// 內置單詞屬性鍵
/// </summary>
// [Obsolete("用帶實例的")]
// public class Const_PropKey{
// 	public const str meaning = nameof(meaning);
// 	//public const str learn = nameof(learn);
// 	public const str annotation = nameof(annotation);
// 	public const str tag = nameof(tag);
// 	public const str source = nameof(source);
// 	public const str alias = nameof(alias);
// 	public const str pronunciation = nameof(pronunciation);
// 	public const str weight = nameof(weight);
// 	public static Dictionary<str, nil> PropKeyMap = new Dictionary<str, nil>() {
// 		{ meaning, Nil },
// 		{ annotation, Nil },
// 		{ tag, Nil },
// 		{ source, Nil },
// 		{ alias, Nil },
// 		{ pronunciation, Nil },
// 		{ weight, Nil }
// 	};

// }
