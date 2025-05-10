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

	public static IList<str> ErrsToStrs<T>(this I_Answer<T> z){
		return z.Errors.Select(e =>{
			return e?.ToString()??"";
		}).ToList();
	}

	public static nil ThrowIfNotOk<T>(this I_Answer<T> z){
		if(!z.Ok){
			var err = str.Join("\n", z.ErrsToStrs());
			throw new Exception(err);
		}
		return Nil;
	}
}
