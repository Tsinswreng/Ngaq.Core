namespace Ngaq.Core.Shared.User.UserCtx;

using Ngaq.Core.Shared.User.Models.Po.User;

public partial class UserCtx
	: IUserCtx
{
	public UserCtx(){

	}
	public IdUser UserId{get;set;} = IdUser.Zero;
	public IDictionary<str, obj?>? Kv{get;set;}

}




