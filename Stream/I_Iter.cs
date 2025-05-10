namespace Ngaq.Core.Stream;

//[Obsolete("改用IEnumerator<T>")]
public interface I_Iter<out T> {
	bool HasNext();
	/// <summary>
	/// 不必判斷有無下一個元素、若用者欲判斷則先用HasNext()
	/// </summary>
	/// <returns></returns>
	T Next();
}
