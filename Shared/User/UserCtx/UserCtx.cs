namespace Ngaq.Core.Shared.User.UserCtx;

using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Tools;

public partial class UserCtx
	: IUserCtx
{
	public UserCtx(){

	}
	public IdUser _UserId = IdUser.Zero;
	public IdUser UserId{get{
		if(_UserId.IsNullOrDefault()){
			throw ItemsErr.User.AuthenticationFailed.ToErr();
		}
		return _UserId;
	}set{
		_UserId = value;
	}}
	public IDictionary<str, obj?>? Props{get;set;}

}




