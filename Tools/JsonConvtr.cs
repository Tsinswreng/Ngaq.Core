namespace Ngaq.Core.Tools;
using System.Text.Json.Serialization;
using System.Text.Json;

// 非泛型抽象基类，避免反射 MakeGenericType
// internal abstract class AotSafeInterfaceConverter : JsonConverterFactory {
// 	public sealed override bool CanConvert(Type type) =>
// 		type.IsValueType &&
// 		typeof(I_ToSerialized).IsAssignableFrom(type) &&
// 		typeof(I_ToDeSerialized).IsAssignableFrom(type);

// 	// 由源生成器在编译期生成并注册到 Converters 中
// 	protected abstract JsonConverter? CreateConverterCore(Type type);
// }

// 源生成器会针对每个 T 生成一个 partial 方法实现
public partial class JsonConvtr<T> : JsonConverter<T>
	where T : struct, IDictSerializable {
	public sealed override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
		using JsonDocument doc = JsonDocument.ParseValue(ref reader);
		JsonElement ele = doc.RootElement;

		object? raw = ele.ValueKind switch {
			JsonValueKind.String => ele.GetString(),
			JsonValueKind.Number when ele.TryGetInt64(out long l) => l,
			JsonValueKind.Number => ele.GetDouble(),
			_ => null
		};

		T instance = default;
		return (T)instance.ToDeSerialized(raw)!;
	}

	public sealed override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
		object? raw = value.ToSerialized(value);
		// 用源生成上下文序列化裸值，彻底避开反射
		JsonSerializer.Serialize(writer, raw, RawValueCtx.Default.Object);
	}
}

[JsonSourceGenerationOptions(
    WriteIndented = false,
    PropertyNamingPolicy = JsonKnownNamingPolicy.Unspecified)]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(object))]
internal partial class RawValueCtx : JsonSerializerContext { }
