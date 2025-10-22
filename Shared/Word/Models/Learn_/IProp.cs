namespace Ngaq.Core.Shared.Word.Models.Learn_;

using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Ngaq.Core.Infra;



public partial interface IProp:IPoKv{

}

public partial class Prop
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

