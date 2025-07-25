using Ngaq.Core.Model.Po.Kv;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Word.Models.Learn_;

public  partial interface I_StrKey_Props{
	public IDictionary<str, IList<IProp>> StrKey_Props{get;set;}
	#if Impl
	= new Dictionary<str, IList<IProp>>();
	#endif
}

public static class ExtnI_StrKey_Props{
	public static IDictionary<str, IList<IProp>> FromPoKvs(
		this IDictionary<str, IList<IProp>> z
		,IEnumerable<PoWordProp> PoKvs
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

