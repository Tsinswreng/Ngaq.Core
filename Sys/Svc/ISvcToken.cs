namespace Ngaq.Core.Sys.Svc;

public interface ISvcToken{
	public str GenAccessToken(
		str UserIdStr
	);

	public str GenRefreshToken(
		str UserIdStr
	);
}
