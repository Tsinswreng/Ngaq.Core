namespace Ngaq.Core.Frontend.User;

using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Shared.User.UserCtx;

/// <summary>
/// do not use UserId in IFrontendUserCtx. Use LocalUserId or RemoteUserId
/// </summary>
public interface IFrontendUserCtx: IUserCtx{
	public str? AccessToken{get;set;}
	public str? RefreshToken{get;set;}
	public IdUser LocalUserId{get;set;}
	public IdUser RemoteUserId{get;set;}
}
