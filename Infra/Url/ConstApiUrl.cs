namespace Ngaq.Core.Infra.Url;

using Tsinswreng.CsCfg;
using Tsinswreng.CsTools;
using static Url;

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

	public static Url V1 = Mk(null, ["V1"]);
		public static Url Sys = Mk(V1, ["Sys"]);
			public static Url User = Mk(Sys, ["User"]);
			//~User
		//~Sys
	//~V1

	public partial class UrlUser{
		//public static Url _Root = "";
		public static Url _Root = User;
		public static Url Login = Mk(_Root, [nameof(Login)]);
		public static Url Logout = Mk(_Root, [nameof(Logout)]);
		public static Url AddUser = Mk(_Root, [nameof(AddUser)]);
	}

}

