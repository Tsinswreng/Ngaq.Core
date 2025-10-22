namespace Ngaq.Core.Domains.User.UserCtx;

using Ngaq.Core.Domains.User.Models.Po.User;

public partial class UserCtx
	: IUserCtx
{
	public UserCtx(){

	}
	public IdUser UserId{get;set;} = IdUser.Zero;
}




