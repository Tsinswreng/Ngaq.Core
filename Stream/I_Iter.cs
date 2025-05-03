namespace Ngaq.Core.Stream;

public interface I_Iter<T>{
	bool HasNext();
	T Next();
}