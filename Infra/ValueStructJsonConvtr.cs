using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ngaq.Core.Infra;

// public sealed class ValueStructJsonConvtr<TStrong, TPrimitive>
// 	: JsonConverter<TStrong>
// 	where TStrong : struct, I_Value<TPrimitive>
// 	where TPrimitive : IComparable<TPrimitive>
// {
// 	public override TStrong Read(
// 		ref Utf8JsonReader reader,
// 		Type typeToConvert,
// 		JsonSerializerOptions options)
// 	{
// 		var primitive = JsonSerializer.Deserialize<TPrimitive>(ref reader, options)!;
// 		return (TStrong)Activator.CreateInstance(typeof(TStrong), primitive)!;
// 	}

// 	public override void Write(
// 		Utf8JsonWriter writer,
// 		TStrong value,
// 		JsonSerializerOptions options)
// 	{
// 		JsonSerializer.Serialize(writer, value.Value, options);
// 	}
// }



// public sealed class ValueStructJsonConvtr<TStrong, TPrimitive>
// 	: JsonConverter<TStrong>
// 	where TStrong : struct, I_Value<TPrimitive>
// 	where TPrimitive : IComparable<TPrimitive>
// {
// 	public override TStrong Read(
// 		ref Utf8JsonReader reader,
// 		Type typeToConvert,
// 		JsonSerializerOptions options)
// 	{
// 		var primitive = JsonSerializer.Deserialize<TPrimitive>(ref reader, options)!;
// 		return (TStrong)Activator.CreateInstance(typeof(TStrong), primitive)!;
// 	}

// 	public override void Write(
// 		Utf8JsonWriter writer,
// 		TStrong value,
// 		JsonSerializerOptions options)
// 	{
// 		JsonSerializer.Serialize(writer, value.Value, options);
// 	}
// }
