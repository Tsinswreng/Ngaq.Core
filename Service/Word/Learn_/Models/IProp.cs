using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface IProp:IPoKv{

}

public class Prop
	:PoKv
	,IProp
{

}

public static class ExtnIProp{
	public static IProp ToIProp(
		this IPoKv z
	){
		var SrcDict = DictCtx.ToDict(z);
		var R = new Prop();
		DictCtx.Assign(R, SrcDict);

		return R;
	}
}

