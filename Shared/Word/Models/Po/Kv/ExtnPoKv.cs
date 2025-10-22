namespace Ngaq.Core.Shared.Word.Models.Po.Kv;
public static class ExtnPoKv{
	public static TSelf SetStr<TSelf>(this TSelf z, str K, str V)
		where TSelf : class, IPoKv
	{
		z.KType = EKvType.Str;
		z.VType = EKvType.Str;
		z.KStr = K;
		z.VStr = V;
		return z;
	}

	public static obj GetKey(this IPoKv z){
		obj Key = null!;
		if(z.KType == EKvType.Str){
			Key = z.KStr!;
		}else{
			Key = z.KI64;
		}
		return Key;
	}
}
