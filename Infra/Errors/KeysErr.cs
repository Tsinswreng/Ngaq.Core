namespace Ngaq.Core.Infra.Errors;

using K = IErrItem;
using static ErrItem;


public static class ItemsErr{
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
