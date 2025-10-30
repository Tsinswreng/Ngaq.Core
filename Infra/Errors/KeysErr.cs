namespace Ngaq.Core.Infra.Errors;
using K = IErrKeySeg;
using static ErrKeySeg;
using Tsinswreng.CsCfg;

public static class TagsErr{
	public static str BadReq = nameof(BadReq);
	public static str SrvErr = nameof(SrvErr);
}

public interface IErrKeySeg:ICfgItem{
	public ISet<str> Tags{get;set;}
}

public class ErrKeySeg:CfgItem<nil>, K {
	public ISet<str> Tags{get;set;} = new HashSet<str>();
	public static IErrKeySeg Mk(IErrKeySeg? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = new ErrKeySeg();
		R.Parent = Parent;
		R.RelaPathSegs = Path;
		if(Tags != null){
			R.Tags.UnionWith(Tags);
		}
		return R;
	}

	public static IErrKeySeg MkC(IErrKeySeg? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = Mk(Parent, Path, Tags);
		R.Tags.Add(TagsErr.BadReq);
		return R;
	}

	public static IErrKeySeg MkS(IErrKeySeg? Parent, IList<str> Path, IList<str>? Tags = null){
		var R = Mk(Parent, Path, Tags);
		R.Tags.Add(TagsErr.SrvErr);
		return R;
	}
}

public static class ExtnErrKeySeg{
	public static ErrBase ToErr(this IErrKeySeg z, params obj?[] Args){
		return ErrBase.Mk(z, Args);
	}
}


public static class KeysErr{
	public static class Common{
		public static K _R = Mk(null, [nameof(Common)]);
		public static K ArgErr = MkC(_R, [nameof(ArgErr)]);
	}
	public class User{
		public static K _R = Mk(null, [nameof(User)]);
		public static K UserNotExist = MkC(_R, [nameof(UserNotExist)]);
		public static K UserAlreadyExist = MkC(_R, [nameof(UserAlreadyExist)]);
		public static K PasswordNotMatch = MkC(_R, [nameof(PasswordNotMatch)]);
		public static K InvalidToken = MkC(_R, [nameof(InvalidToken)]);
		public static K TokenExpired = MkC(_R, [nameof(TokenExpired)]);
	}
}
