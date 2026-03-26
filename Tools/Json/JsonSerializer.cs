namespace Ngaq.Core.Tools.Json;

public class AppJsonSerializer:IJsonSerializer{
	public static AppJsonSerializer Inst => field??=new();
	[Impl]
	public str Stringify<T>(T O){
		return JSON.Stringify(O);
	}

	[Impl]
	public T? Parse<T>(str Json){
		return JSON.Parse<T>(Json);
	}

	[Impl]
	public obj? Parse(str Json, Type Type){
		return JSON.Parse(Json, Type);
	}
}
