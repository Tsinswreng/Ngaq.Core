using Tsinswreng.CsTools.Tools;

namespace Ngaq.Core.Infra;

public class ConstApiUrl{
	protected static ConstApiUrl? _Inst = null;
	public static ConstApiUrl Inst => _Inst??= new ConstApiUrl();

	str ApiVi => "/Api-V1";
	str Sys => "/Sys";
	//public str ApiV1SysUser => "/Api-V1/Sys/User";
	public str ApiV1SysUser => ToolPath.SlashTrimEtJoin([ApiVi, Sys, "User"]);
}

public class ApiUrl_User{
	protected static ApiUrl_User? _Inst = null;
	public static ApiUrl_User Inst => _Inst??= new ApiUrl_User();

	public str Login => "/Login";
	public str Logout => "/Logout";
	public str AddUser => "/AddUser";
}
