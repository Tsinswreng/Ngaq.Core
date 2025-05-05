namespace Ngaq.Core.Infra.Core;
public static class Extn_I_Answer{
	public static nil AddErrStr<T>(this I_Answer<T> z, str s){
		z.Errors.Add(s);
		return Nil;
	}

	public static nil AddErrException<T>(this I_Answer<T> z, Exception e){
		z.Errors.Add(e);
		return Nil;
	}
}
