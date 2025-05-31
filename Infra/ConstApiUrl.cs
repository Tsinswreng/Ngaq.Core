namespace Ngaq.Core.Infra;

public class ConstApiUrl{
	protected static ConstApiUrl? _Inst = null;
	public static ConstApiUrl Inst => _Inst??= new ConstApiUrl();

	public str ApiV1SysUser => "api-v1/sys/user/";
}

public class ApiUrl_User{
	protected static ApiUrl_User? _Inst = null;
	public static ApiUrl_User Inst => _Inst??= new ApiUrl_User();

	public str Login => "login";
	public str Logout => "logout";
	public str Register => "register";
}
