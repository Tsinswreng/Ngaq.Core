namespace Ngaq.Core.Model.Po.Kv;

public class Const_Tokens{
	/// <summary>
	/// 命名空間與名 之分隔符
	/// 適用于Const_PropKey及Const_Learn等
	/// 內置鍵名等皆在頂級命名空間下 如":annotation", ":tag"等
	/// 用戶自定義鍵名則在用戶命名空間下 如"Tsinswreng:Annotation"
	/// </summary>
	public const str Sep_NamespaceEtName = ":";
}
