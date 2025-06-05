using Ngaq.Core.Model.Po.Kv;
using Tsinswreng.CsCore.Tools.MultiDict;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface I_StrKey_Props{
	public IDictionary<str, IList<IProp>> StrKey_Props{get;set;}
	#if Impl
	= new Dictionary<str, IList<IProp>>();
	#endif
}

public static class ExtnI_StrKey_Props{
	public static IDictionary<str, IList<IProp>> FromPoKvs(
		this IDictionary<str, IList<IProp>> z
		,IEnumerable<PoKv> PoKvs
	){
		foreach(var PoKv in PoKvs){
			if(PoKv.KType == (i64)EKvType.Str){
				var Prop = PoKv.ToIProp();
				z.AddInValues(
					PoKv.KStr??""
					,Prop
				);
			}
		}
		return z;
	}
}

