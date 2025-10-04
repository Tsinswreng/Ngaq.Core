namespace Ngaq.Core.Tools.Json;

public interface IJsonSerializer{
	public str Stringify<T>(T o);
	public T Parse<T>(str json);
	public obj? Parse(str json, Type Type);
}


