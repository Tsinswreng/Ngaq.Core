namespace Ngaq.Core.Shared.User.Svc;

public interface ISvcToken{
	public str GenAccessToken(
		str UserIdStr
	);

	public str GenRefreshToken(
		str UserIdStr
	);


}
