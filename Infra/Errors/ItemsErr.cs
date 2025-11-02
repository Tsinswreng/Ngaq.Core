namespace Ngaq.Core.Infra.Errors;

using K = IErrItem;
using static ErrItem;


public static class ItemsErr{
	public static class Common{
		public static K _R = Mk(null, [nameof(Common)]);
		public static K ArgErr = MkB(_R, [nameof(ArgErr)]);
		public static K UnknownErr = MkB(_R, [nameof(UnknownErr)]);
	}
	public class User{
		public static K _R = Mk(null, [nameof(User)]);
		public static K UserNotExist = MkB(_R, [nameof(UserNotExist)]);
		public static K UserAlreadyExist = MkB(_R, [nameof(UserAlreadyExist)]);
		public static K PasswordNotMatch = MkB(_R, [nameof(PasswordNotMatch)]);
		public static K InvalidToken = MkB(_R, [nameof(InvalidToken)]);
		public static K TokenExpired = MkB(_R, [nameof(TokenExpired)]);
		public static K AuthenticationFailed = MkB(_R, [nameof(AuthenticationFailed)]);
	}
	public class Word{
		public static K _R = Mk(null, [nameof(Word)]);
		public static K LoadWordListFailed = MkB(_R, [nameof(LoadWordListFailed)]);
		public static K SaveWordListFailed = MkB(_R, [nameof(SaveWordListFailed)]);
		
	}
}
