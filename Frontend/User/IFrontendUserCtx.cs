namespace Ngaq.Core.Frontend.User;
using Ngaq.Core.Shared.User.UserCtx;

public interface IFrontendUserCtx: IUserCtx{
	public str? AccessToken{get;set;}
	public str? RefreshToken{get;set;}
}
