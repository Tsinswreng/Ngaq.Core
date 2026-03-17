namespace Ngaq.Core.Tools.Json;

public interface IJsonSerializer{
	public str Stringify<T>(T O);
	public T Parse<T>(str Json);
	public obj? Parse(str Json, Type Type);
}

