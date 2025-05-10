namespace Ngaq.Core.Infra.Core;
/// <summary>
/// 緣void不可作泛型參數、則以此代。
/// nil SomeFunction(){
/// 	return Nil;
/// }
/// </summary>
public struct Nil_{
	public const nil Nil = null!;
}
