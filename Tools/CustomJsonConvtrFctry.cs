using System.Text.Json;
using System.Text.Json.Serialization;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Tools;

// 统一的 JsonConverterFactory
/// <summary>
/// 對于類型芝叶 I_ToSerialized 及 I_ToDeSerialized 者 做自定義序列化
/// </summary>
[Obsolete("此路不通、須手動蔿每ʹ特ʹ類型 作轉換器")]
public sealed class CustomJsonConvtrFctry : JsonConverterFactory {
	public override bool CanConvert(Type typeToConvert) {
		//typeToConvert.IsValueType &&
		return
			// typeof(I_ToSerialized).IsAssignableFrom(typeToConvert) &&
			// typeof(I_ToDeSerialized).IsAssignableFrom(typeToConvert)
			typeof(IDictSerializable).IsAssignableFrom(typeToConvert)
		;
	}



		public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
			// 用反射拿到泛型定义，然后 MakeGenericType。
			// 这一步只在 App 启动时执行一次，AOT 允许。
	//'T' generic argument does not satisfy 'DynamicallyAccessedMemberTypes.PublicParameterlessConstructor' in 'Ngaq.Core.Tools.CustomJsonConvtrFctry.InterfaceConverter<T>'. The parameter 'typeToConvert' of method 'Ngaq.Core.Tools.CustomJsonConvtrFctry.CreateConverter(Type, JsonSerializerOptions)' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to.(IL2071)
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
//Using member 'System.Text.Json.JsonSerializer.Deserialize(ref Utf8JsonReader, Type, JsonSerializerOptions)' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.(IL2026)
//Using member 'System.Text.Json.JsonSerializer.Deserialize(ref Utf8JsonReader, Type, JsonSerializerOptions)' which has 'RequiresDynamicCodeAttribute' can break functionality when AOT compiling. JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.(IL3050)
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

			// 调用接口方法把裸值还原成 T
			object? boxed = Sample.ToDeSerialized(raw);
			return (T)boxed!;
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
			// 调用接口方法拿到要真正写出去的裸值
			object? raw = value.ToSerialized(value);
//JsonSerializerOptions)' which has 'RequiresDynamicCodeAttribute' can break functionality when AOT compiling. JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.(IL3050)
			JsonSerializer.Serialize(writer, raw, raw?.GetType() ?? typeof(object), options);
		}

		static bool IsInteger(decimal d) => decimal.Truncate(d) == d;

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
