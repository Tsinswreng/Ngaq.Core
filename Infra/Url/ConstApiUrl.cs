namespace Ngaq.Core.Infra.Url;

using Ngaq.Core.Tools;
using Tsinswreng.CsCfg;
using Tsinswreng.CsTools;
using static Ngaq.Core.Tools.Url;

// public interface I_staticMk{
// 	public abstract static str Mk();
// }

// public struct KeyStr<T>(str V)
// 	where T:I_staticMk
// {
// 	public str Value => V;
// 	public static implicit operator str(KeyStr<T> e){
// 		return e.Value;
// 	}
// 	public static implicit operator Url(KeyStr<T> s){
// 		return new KeyStr<T>(s);
// 	}
// 	public static KeyStr<T> Mk(
// 		KeyStr<T>? Parent
// 		,IList<str> Path
// 	){
// 		return
// 	}
// }



public partial class ConstUrl{
	public static Url OpenV1 = Mk(null, ["Open", "V1"]);
	//~Open
		public static Url ApiV1 = Mk(null, ["Api", "V1"]);
			public static Url _ApiUser = Mk(ApiV1, ["Sys", "User"]);
			//~Sys
			public static Url Word = Mk(ApiV1, [nameof(Word)]);
			//~Word
		//~V1
	//~Api

	//勿作深層內部類。䀬ʹ子ʹApi枚舉內部類只置于ConstUrlʹ直ʹ子層
	public partial class OpenUser{
		//public static Url _Root = "";
		public static Url _R = Mk(OpenV1, ["Sys", "User"]);
		public static Url Login = Mk(_R, [nameof(Login)]);
		public static Url AddUser = Mk(_R, [nameof(AddUser)]);
		public static Url TokenRefresh = Mk(_R, ["Token", "Refresh"]);
	}

	public partial class ApiUser{
		public static Url _R = _ApiUser;
		public static Url Logout = Mk(_R, [nameof(Logout)]);
	}



	public partial class UrlWord{
		public static Url _Root = Word;
		public static Url Push = Mk(_Root, [nameof(Push)]);
		public static Url Pull = Mk(_Root, [nameof(Pull)]);
	}

}

