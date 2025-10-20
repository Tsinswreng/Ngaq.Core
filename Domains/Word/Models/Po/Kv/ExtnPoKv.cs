namespace Ngaq.Core.Domains.Word.Models.Po.Kv;
public static class ExtnPoKv{
	public static nil SetStr(this IPoKv z, str K, str V){
		z.KType = EKvType.Str;
		z.VType = EKvType.Str;
		z.KStr = K;
		z.VStr = V;
		return NIL;
	}
}
