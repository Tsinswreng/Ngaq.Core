namespace Ngaq.Core.Shared.User.Svc;

//TODO 純後端接口也、宜遷
public interface ISvcToken{
	public str GenAccessToken(
		str UserIdStr
	);

	public str GenRefreshToken(
		str UserIdStr
	);
}
