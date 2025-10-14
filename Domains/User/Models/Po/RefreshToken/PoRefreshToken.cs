namespace Ngaq.Core.Domains.User.Models.Po.RefreshToken;

using Ngaq.Core.Domains.User.Models.Bo.Device;
using Ngaq.Core.Domains.User.Models.Bo.Jwt;
using Ngaq.Core.Domains.User.Models.Po.Device;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.RefreshToken;
using Ngaq.Core.Models.Po;

public class PoSession
	:PoBase
	,I_Id<IdSession>
{
	public enum ETokenValueType{
		Sha256,
	}

	public override Tempus CreatedAt { get => base.CreatedAt; set => base.CreatedAt = value; }
	public IdSession Id{get;set;}
	public Jti Jti{get;set;}
	public IdUser UserId{get;set;}
	public ETokenValueType TokenValueType{get;set;}
	public u8[]? TokenValue{get;set;}
	/// <summary>
	/// 客戶端生成後持久化ᵈ存
	/// </summary>
	public IdDevice DeviceId{get;set;}
	public EDeviceType DeviceType{get;set;} = EDeviceType.Unknown;
	public Tempus ExpireAt{get;set;}
	public Tempus? RevokeAt{get;set;}
	public str? RevokeReason{get;set;}
	public str? IpAddr{get;set;}
	public Tempus? LastUsedAt{get;set;}
	/// <summary>
	/// 保留備用。萬一以後要給第三方限制介面範圍，可直接沿用 OAuth2 scope 思維。
	/// </summary>
	public str? Scope{get;set;}
	public str? UserAgent{get;set;}
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
