namespace Ngaq.Core.Stream;

public interface I_Iter<out T>{
	bool HasNext();
	T Next();
}
