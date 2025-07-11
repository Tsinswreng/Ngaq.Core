using System.Text.Json;
using System.Text.Json.Serialization;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Tools;

public class ToolId{
	public static UInt128 NewUlidUInt128(){
		var bytes = Ulid.NewUlid().ToByteArray();
		return ToolUInt128.ByteArrToUInt128(bytes);
	}
}

// public class StronglyTypedIdJsonConverter<TStronglyTyped, TValue> : JsonConverter<TStronglyTyped>
// 	where TStronglyTyped : I_Value<> new()
// {
// 	public override void Write(
// 		Utf8JsonWriter writer
// 		,TStronglyTyped StrongTyped
// 		,JsonSerializerOptions options
// 	)
// 	{
// 		// 这里假设TStronglyTypedId有Value字段或者ToString覆盖了
// 		var stringValue = StrongTyped?.ToString();  // 或者获取内部数字值
// 		writer.WriteStringValue(stringValue);
// 	}

// 	public override TStronglyTyped Read(
// 		ref Utf8JsonReader reader
// 		,Type typeToConvert,
// 		JsonSerializerOptions options
// 	){
// 		var stringValue = reader.GetString();
// 		// 这里你需要提供从string构造TStronglyTypedId的逻辑，比方静态工厂方法Parse
// 		return new TStronglyTyped(stringValue);
// 		//return TStronglyTypedId.Parse(stringValue); // 你自己实现Parse方法
// 	}
// }
