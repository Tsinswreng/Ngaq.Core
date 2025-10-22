namespace Ngaq.Core.Domains.User.UserCtx;

public interface IFrontendUserCtx: IUserCtx{
	public str? AccessToken{get;set;}
	public str? RefreshToken{get;set;}
}
