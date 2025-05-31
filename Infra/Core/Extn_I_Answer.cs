namespace Ngaq.Core.Infra.Core;

public static class Extn_I_Answer{
	public static IAnswer<T> AddErrStr<T>(this IAnswer<T> z, str s){
		z.Ok = false;
		z.Errors.Add(s);
		return z;
	}

	public static IAnswer<T> AddErrException<T>(this IAnswer<T> z, Exception e){
		z.Ok = false;
		z.Errors.Add(e);
		return z;
	}
	public static IAnswer<T> OkWith<T> (this IAnswer<T> z, T data = default!){
		z.Data = data;
		z.Ok = true;
		return z;
	}

	public static IList<str> ErrsToStrs<T>(this IAnswer<T> z){
		return z.Errors.Select(e =>{
			return e?.ToString()??"";
		}).ToList();
	}

	public static T DataOrThrow<T>(this IAnswer<T> z){
		if(!z.Ok){
			var err = str.Join("\n", z.ErrsToStrs());
			throw new Exception(err);
		}
		return z.Data!;
	}
}
