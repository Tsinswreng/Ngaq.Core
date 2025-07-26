using YamlDotNet.Serialization;

namespace Ngaq.Core.Tools;

public  partial class Yaml {
	public static IDictionary<str, object> YamlToDict(
		str yaml
	) {
		var deserializer = new DeserializerBuilder()
					//.WithNamingConvention(CamelCaseNamingConvention.Instance)
			.Build();
		var obj = deserializer.Deserialize<object>(yaml);
		var dict = deserializer.Deserialize<IDictionary<string, object>>(yaml);
		return dict;
	}

}
