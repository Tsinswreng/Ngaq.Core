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

	public static str? GetVStr(this IPoKv z){
		if(z.VType == EKvType.Str){
			return z.VStr;
		}
		throw new InvalidOperationException("VType is not Str.");
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
