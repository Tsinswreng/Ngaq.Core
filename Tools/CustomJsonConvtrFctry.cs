using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ngaq.Core.Tools;

// 统一的 JsonConverterFactory
/// <summary>
/// 對于類型芝叶 I_ToSerialized 及 I_ToDeSerialized 者 做自定義序列化
/// </summary>
public sealed class CustomJsonConvtrFctry : JsonConverterFactory {
	public override bool CanConvert(Type typeToConvert) {
		//typeToConvert.IsValueType &&
		return
			typeof(I_ToSerialized).IsAssignableFrom(typeToConvert) &&
			typeof(I_ToDeSerialized).IsAssignableFrom(typeToConvert)
		;
	}

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
		// 用反射拿到泛型定义，然后 MakeGenericType。
		// 这一步只在 App 启动时执行一次，AOT 允许。
		var convType = typeof(InterfaceConverter<>).MakeGenericType(typeToConvert);
		return (JsonConverter)Activator.CreateInstance(convType)!;
	}

	// 真正的泛型 Converter
	private sealed class InterfaceConverter<T> : JsonConverter<T>
		where T : struct, I_ToSerialized, I_ToDeSerialized
	{
		public T Sample = new();
		//反序列化
		public override T Read(ref Utf8JsonReader reader, Type TarType, JsonSerializerOptions options) {
			// 先反序列化接口方法返回的“裸值”
			var objJsonEle = JsonSerializer.Deserialize(
				ref reader
				,typeof(object)
				,options
			);
			var jsonEle = (JsonElement)objJsonEle!;
			obj? raw = null;
			if(jsonEle.ValueKind == JsonValueKind.String){
				raw = jsonEle.GetString();
			}else if(jsonEle.ValueKind == JsonValueKind.Number){
				var deci = jsonEle.GetDecimal();
				if(IsInteger(deci)){
					raw = Convert.ToInt64(deci);
				}else{
					raw = Convert.ToDouble(deci);
				}
			}
			// var t = objJsonEle.GetType();//t
			// System.Console.WriteLine(t);//t JsonElement
			// 调用接口方法把裸值还原成 T
			object? boxed = Sample.ToDeSerialized(raw);
			return (T)boxed!;
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
			// 调用接口方法拿到要真正写出去的裸值
			object? raw = value.ToSerialized(value);
			JsonSerializer.Serialize(writer, raw, raw?.GetType() ?? typeof(object), options);
		}

		static bool IsInteger(decimal d) => decimal.Truncate(d) == d;

		// static object? ExtractJsonElement(JsonElement element, Type targetType){
		// 	// 先处理可空类型
		// 	Type t = Nullable.GetUnderlyingType(targetType) ?? targetType;

		// 	switch (element.ValueKind)
		// 	{
		// 		case JsonValueKind.String:
		// 			if (t == typeof(string))       return element.GetString();
		// 			if (t == typeof(Guid))         return element.GetGuid();
		// 			if (t == typeof(DateTime))     return element.GetDateTime();
		// 			if (t == typeof(DateTimeOffset)) return element.GetDateTimeOffset();
		// 			if (t == typeof(byte[]))       return element.GetBytesFromBase64();
		// 			// 其他需要字符串构造的可以继续加
		// 			return element.GetString();    //  fallback

		// 		case JsonValueKind.Number:
		// 			// 先拿 decimal，再转成目标数字类型，避免溢出
		// 			decimal d = element.GetDecimal();
		// 			if (t == typeof(decimal)) return d;
		// 			if (t == typeof(double))  return (double)d;
		// 			if (t == typeof(float))   return (float)d;
		// 			if (t == typeof(long))    return (long)d;
		// 			if (t == typeof(int))     return (int)d;
		// 			if (t == typeof(short))   return (short)d;
		// 			if (t == typeof(byte))    return (byte)d;
		// 			return d;

		// 		case JsonValueKind.True:
		// 		case JsonValueKind.False:
		// 			return element.GetBoolean();

		// 		case JsonValueKind.Null:
		// 			return null;

		// 		default:
		// 			// 数组/对象可以再继续 Deserialize
		// 			return element.Deserialize(targetType);
		// 	}
		// }
	}
}


#if false

// AOT 需要的 JsonSerializerContext
[JsonSourceGenerationOptions(
	GenerationMode = JsonSourceGenerationMode.Serialization | JsonSourceGenerationMode.Metadata,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(UserId))]
[JsonSerializable(typeof(Guid))]
internal partial class AppJsonContext : JsonSerializerContext {
	// 把自定义 Factory 挂进来
	private static readonly JsonSerializerOptions s_options =
		new(JsonSerializerDefaults.Web) {
			Converters = { new AotFriendlyInterfaceConverterFactory() }
		};

	// 对外暴露统一入口
	public static string ToJson<T>(T value) =>
		JsonSerializer.Serialize(value, typeof(T), AppJsonContext.Default);

	public static T? FromJson<T>(string json) =>
		JsonSerializer.Deserialize(json, typeof(T), AppJsonContext.Default) is T v ? v : default;
}

#endif
