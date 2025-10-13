namespace Ngaq.Core.Models.Sys.Po.RefreshToken;

using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.RefreshToken;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

public class PoRefreshToken
	:PoBase
	,I_Id<IdRefreshToken>
{
	public enum EType{
		Sha256,
	}

	public IdRefreshToken Id{get;set;}
	public IdUser UserId{get;set;}
	public EType Type{get;set;}
	public u8[]? Data{get;set;}
	public Tempus ExpireAt{get;set;}
	public Tempus? RevokeAt{get;set;}
	public str? RevokeReason{get;set;}
	public str? IpAddr{get;set;}
	public Tempus? LastUsedAt{get;set;}

}
/*
Id (PK, bigint)
UserId (FK → Users.Id)
TokenHash (char(88) or varchar(200)) ※把 Refresh-Token 先 SHA256 再存，防 DBA 直接抄走
ExpiresUtc (datetime)
CreatedUtc (datetime)
RevokedUtc (datetime, nullable)
RevokeReason (varchar(50), nullable) ※例：Logout、PasswordChanged、AdminKick
DeviceInfo (varchar(200), nullable) ※可選，用來區分手機/瀏覽器
IpAddress (varchar(45), nullable) ※可選，記錄發放 IP
LastUsedUtc (datetime, nullable) ※可選，用來清掃長期未用的髒資料
 */
