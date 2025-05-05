namespace Ngaq.Core.Infra.Core;

public static class Extn_I_Answer{
	public static I_Answer<T> AddErrStr<T>(this I_Answer<T> z, str s){
		z.Ok = false;
		z.Errors.Add(s);
		return z;
	}

	public static I_Answer<T> AddErrException<T>(this I_Answer<T> z, Exception e){
		z.Ok = false;
		z.Errors.Add(e);
		return z;
	}
	public static I_Answer<T> OkWith<T> (this I_Answer<T> z, T data = default!){
		z.Data = data;
		z.Ok = true;
		return z;
	}
}
