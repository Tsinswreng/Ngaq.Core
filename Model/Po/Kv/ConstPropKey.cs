namespace Ngaq.Core.Model.Po.Kv;

/// <summary>
/// 內置單詞屬性鍵
/// </summary>
public class Const_PropKey{
	public const str meaning = nameof(meaning);
	//public const str learn = nameof(learn);
	public const str annotation = nameof(annotation);
	public const str tag = nameof(tag);
	public const str source = nameof(source);
	public const str alias = nameof(alias);
	public const str pronunciation = nameof(pronunciation);
	public const str weight = nameof(weight);
	public static Dictionary<str, nil> PropKeyMap = new Dictionary<str, nil>() {
		{ meaning, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ annotation, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ tag, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ source, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ alias, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ pronunciation, Tsinswreng.CsTypeAlias.Nil_.nil },
		{ weight, Tsinswreng.CsTypeAlias.Nil_.nil }
	};

}
