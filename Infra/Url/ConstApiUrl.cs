namespace Ngaq.Core.Infra.Url;

using Tsinswreng.CsCfg;
using Tsinswreng.CsTools;
using static Url;
public record struct Url(str V){
	public str Value => V;
	public static implicit operator str(Url e){
		return e.Value;
	}
	public static implicit operator Url(str s){
		return new Url(s);
	}
	public override string ToString() {
		return Value;
	}
	public static Url Mk(
		Url? Parent
		,IList<str> Path
		//,str DfltValue = default!
	){
		Parent??= "";
		return ToolPath.SlashTrimEtJoin([Parent, ..Path]);
	}
}

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
		public static Url Login = Mk(_Root, ["Login"]);
		public static Url Logout = Mk(_Root, ["Logout"]);
		public static Url AddUser = Mk(_Root, ["AddUser"]);
	}

}

