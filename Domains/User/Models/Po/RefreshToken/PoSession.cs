namespace Ngaq.Core.Domains.User.Models.Po.RefreshToken;

using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Domains.User.Models.Bo.Device;
using Ngaq.Core.Domains.User.Models.Bo.Jwt;
using Ngaq.Core.Domains.User.Models.Po.Device;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.RefreshToken;
using Ngaq.Core.Models.Po;

/// <summary>
/// 刷新令牌
/// </summary>
public class PoSession
	:PoBase
	,I_Id<IdSession>
	,IBizCreateUpdateTime
{
	public enum ETokenValueType{
		Sha256,
	}


	public IdSession Id{get;set;}
	public Jti Jti{get;set;}
	public IdUser UserId{get;set;}
	public ETokenValueType TokenValueType{get;set;}
	public u8[]? TokenValue{get;set;}
	/// <summary>
	/// 客戶端生成後持久化ᵈ存
	/// 如 同一用戶可能同時在 手機與電腦登入/登出
	/// </summary>
	public IdClient ClientId{get;set;}
	public EClientType ClientType{get;set;} = EClientType.Unknown;
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
	#region IBizCreateUpdateTime
	/// <summary>
	/// 理則ₐ實體ˇ增ʹ時、如于單詞、則始記于文本單詞表中之時 即其CreatedAt、非 存入數據庫之時
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus CreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	/// <summary>
	/// 理則ₐ實體ˇ改ʹ時
	/// 如ʃ有ʹ子實體ˋ變˪、則亦宜改主實體或聚合根ʹUpdatedAt
	/// </summary>
	public Tempus UpdatedAt{get;set;}
	#if Impl
		= Tempus.Zero;
	#endif

	#endregion IBizCreateUpdateTime
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
