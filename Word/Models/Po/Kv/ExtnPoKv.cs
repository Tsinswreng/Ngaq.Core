namespace Ngaq.Core.Model.Po.Kv;

public static class Extn_Po_Kv{
	public static nil SetStr(this IPoKv z, str k, str v){
		z.KType = (i64)EKvType.Str;
		z.VType = (i64)EKvType.Str;
		z.KStr = k;
		z.VStr = v;
		return NIL;
	}
}
