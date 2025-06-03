using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface IProp:IPoKv{

}

public static class ExtnIProp{
	public static IProp ToIProp(
		this IPoKv z
	){
		if(z is IProp prop){
			return prop;
		}
		throw new InvalidCastException("z is not IProp");
	}
}

