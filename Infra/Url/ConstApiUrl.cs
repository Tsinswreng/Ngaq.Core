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
	public static Url OpenUser = Mk(OpenV1, ["Sys", "User"]);
	//~Open
		public static Url ApiV1 = Mk(null, ["Api", "V1"]);
			public static Url User = Mk(ApiV1, ["Sys", "User"]);
			//~Sys
			public static Url Word = Mk(ApiV1, [nameof(Word)]);
			//~Word
		//~V1
	//~Api

	//勿作深層內部類。䀬ʹ子ʹApi枚舉內部類只置于ConstUrlʹ直ʹ子層
	public partial class UrlOpenUser{
		//public static Url _Root = "";
		public static Url _Root = OpenUser;
		public static Url Login = Mk(_Root, [nameof(Login)]);
		public static Url AddUser = Mk(_Root, [nameof(AddUser)]);
	}

	public partial class UrlUser{
		public static Url _Root = User;
		public static Url TokenRefresh = Mk(_Root, ["Token", "Refresh"]);
	}



	public partial class UrlWord{
		public static Url _Root = Word;
		public static Url Push = Mk(_Root, [nameof(Push)]);
		public static Url Pull = Mk(_Root, [nameof(Pull)]);
	}

}

