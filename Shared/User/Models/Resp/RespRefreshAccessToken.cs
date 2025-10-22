namespace Ngaq.Core.Shared.User.Models.Resp;

using Ngaq.Core.Shared.Base.Models.Resp;
using Ngaq.Core.Infra;

public class RespRefreshAccessToken:IResp{
	public str? RefreshToken {get;set;}
	public Tempus RefreshTokenExpireAt{get;set;}
	public str AccessToken { get; set; } = "";
	public Tempus AccessTokenExpireAt { get; set; }
}
