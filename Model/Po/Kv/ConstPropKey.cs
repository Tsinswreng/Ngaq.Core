namespace Ngaq.Core.Model.Po.Kv;


/// <summary>
/// 內置單詞屬性鍵
/// </summary>
public class KeysProp{
	protected static KeysProp? _Inst = null;
	public static KeysProp Inst => _Inst??= new KeysProp();

	public str summary = nameof(summary);
	public str description = nameof(description);
	//public str learn = nameof(learn);
	public str note = nameof(note);
	public str tag = nameof(tag);
	public str source = nameof(source);
	public str alias = nameof(alias);
	public str pronunciation = nameof(pronunciation);
	public str weight = nameof(weight);
	public str learn = nameof(learn);

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
