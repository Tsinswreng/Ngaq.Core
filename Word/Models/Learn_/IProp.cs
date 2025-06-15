using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Word.Models.Learn_;

public interface IProp:IPoKv{

}

public class Prop
	:PoWordProp
	,IProp
{

}

public static class ExtnIProp{
	public static IProp ToIProp(
		this IPoKv z
	){
		var SrcDict = DictCtx.Inst.ToDictT(z);
		var R = new Prop();
		DictCtx.Inst.AssignT(R, SrcDict);

		return R;
	}
}

