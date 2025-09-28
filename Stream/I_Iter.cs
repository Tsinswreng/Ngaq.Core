namespace Ngaq.Core.Stream;

public partial interface IIter<out T> {
	bool HasNext();
	/// <summary>
	/// 不必判斷有無下一個元素、若用者欲判斷則先用HasNext()
	/// </summary>
	/// <returns></returns>
	T Next();
}
