namespace Ngaq.Core.Frontend.User.Svc;
using Ngaq.Core.Infra;
using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsFactoryMkr;

[MkFactory(For=typeof(ReqSetRefreshToken))]
public partial class ReqSetRefreshToken{
	public IdUser LoginUserId{get;set;}
	public str RefreshToken{get;set;} = "";
	public Tempus RefreshTokenExpireAt{get;set;}
}

public interface ISvcTokenStorage{
	public Task<str?> GetRefreshToken(CT Ct);
	[Obsolete]
	public Task<nil> SetRefreshToken(str Token, CT Ct);
	public Task<nil> SetRefreshToken(ReqSetRefreshToken Req, CT Ct);
}

