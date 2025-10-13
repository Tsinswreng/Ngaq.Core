namespace Ngaq.Core.Infra;

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

	public static str V1 = Mk(null, ["V1"]);
		public static str Sys = Mk(V1, ["Sys"]);
			public static str User = Mk(Sys, ["User"]);
			//~User
		//~Sys
	//~V1

	public partial class UrlUser{
		//public static str _Root = "";
		public static str _Root = ConstUrl.User;
		public static str Login = Mk(_Root, ["Login"]);
		public static str Logout = Mk(_Root, ["Logout"]);
		public static str AddUser = Mk(_Root, ["AddUser"]);
	}

}



[Obsolete]
public partial class ConstApiUrlOld{
	protected static ConstApiUrlOld? _Inst = null;
	public static ConstApiUrlOld Inst => _Inst??= new ConstApiUrlOld();

	str ApiVi => "/Api-V1";
	str Sys => "/Sys";
	//public str ApiV1SysUser => "/Api-V1/Sys/User";
	public str ApiV1SysUser => ToolPath.SlashTrimEtJoin([ApiVi, Sys, "User"]);
}

public  partial class ApiUrl_User{
	protected static ApiUrl_User? _Inst = null;
	public static ApiUrl_User Inst => _Inst??= new ApiUrl_User();

	public str Login => "/Login";
	public str Logout => "/Logout";
	public str AddUser => "/AddUser";
}
