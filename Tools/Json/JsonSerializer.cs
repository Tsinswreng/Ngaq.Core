namespace Ngaq.Core.Tools.Json;

public class JsonSerializer:IJsonSerializer{
	[Impl]
	public str Stringify<T>(T o){
		return JSON.stringify(o);
	}

	[Impl]
	public T Parse<T>(str json){
		return JSON.parse<T>(json);
	}
}
