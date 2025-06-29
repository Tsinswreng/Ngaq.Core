namespace Ngaq.Core.Infra.Core;

public static class ExtnIAnswer{
	public static IAnswer<T> AddErrStr<T>(this IAnswer<T> z, str s){
		z.Ok = false;
		z.Errors??= new List<object?>();
		z.Errors.Add(s);
		return z;
	}

	public static IAnswer<T> AddErrException<T>(this IAnswer<T> z, Exception e){
		z.Ok = false;
		z.Errors??= new List<object?>();
		z.Errors.Add(e);
		return z;
	}
	public static IAnswer<T> OkWith<T> (this IAnswer<T> z, T data = default!){
		z.Data = data;
		z.Ok = true;
		return z;
	}

	public static IList<str> ErrsToStrs<T>(this IAnswer<T> z){
		z.Errors??= new List<object?>();
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
