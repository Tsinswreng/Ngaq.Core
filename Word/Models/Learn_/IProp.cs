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
		var SrcDict = CoreDictMapper.Inst.ToDictShallowT(z);
		var R = new Prop();
		CoreDictMapper.Inst.AssignShallowT(R, SrcDict);

		return R;
	}
}

