using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Ngaq.Core.Infra;
namespace Ngaq.Core.Tools;


public static class JSON {
	/// <summary>
	/// 縱Opt中指定了TypeInfoResolver亦不效、肰直ᵈ傳TypeInfo又不可兼傳Opt。故需把選項加于appJsonCtxʹ註解
	/// </summary>
	static JsonSerializerOptions Opt = new JsonSerializerOptions{
		//WriteIndented = true
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 允許原樣輸出
		,PropertyNamingPolicy = null  // 关闭命名策略
		,TypeInfoResolver = AppJsonCtx.Default
		,ReadCommentHandling = JsonCommentHandling.Skip
		//,Converters = { new CustomJsonConvtrFctry() }
		// ,Converters = {

		// }
	};

/*
Using member 'System.Text.Json.JsonSerializer.Serialize<TValue>(TValue, JsonSerializerOptions)' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.(IL2026)
Using member 'System.Text.Json.JsonSerializer.Serialize<TValue>(TValue, JsonSerializerOptions)' which has 'RequiresDynamicCodeAttribute' can break functionality when AOT compiling. JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.(IL3050)
 */
	// public static str stringify<T>(
	// 	T o
	// 	,JsonTypeInfo? jsonTypeInfo = null
	// ){
	// 	if(jsonTypeInfo == null){
	// 		var ans = JsonSerializer.Serialize(o, Opt);
	// 		return ans;
	// 	}
	// 	return JsonSerializer.Serialize(o, jsonTypeInfo);
	// }

	// public static T? parse<T>(
	// 	str json
	// 	,JsonTypeInfo<T>? jsonTypeInfo = null
	// ){
	// 	if(jsonTypeInfo == null){
	// 		return JsonSerializer.Deserialize<T>(json, Opt);
	// 	}
	// 	return JsonSerializer.Deserialize(json, jsonTypeInfo);
	// }


	public static string stringify<T>(T o){
		//return JsonSerializer.Serialize(o, Opt);
		// if (jsonTypeInfo != null){
		// 	return JsonSerializer.Serialize(o, jsonTypeInfo);
		// }

		// ✅ 使用 AppJsonCtx 提供的 type info
		var typeInfo = AppJsonCtx.Inst.GetTypeInfo(typeof(T)) as JsonTypeInfo<T>;
		if (typeInfo == null){
			throw new InvalidOperationException($"Type {typeof(T)} is not registered in AppJsonCtx");
		}

		return JsonSerializer.Serialize(o, typeInfo);
	}

	public static T? parse<T>(string json){
		// if (jsonTypeInfo != null)
		// 	return JsonSerializer.Deserialize(json, jsonTypeInfo);

		// ✅ 使用 AppJsonCtx 提供的 type info
		var typeInfo = AppJsonCtx.Default.GetTypeInfo(typeof(T)) as JsonTypeInfo<T>;
		if (typeInfo == null){
			throw new InvalidOperationException($"Type {typeof(T)} is not registered in AppJsonCtx");
		}
		return JsonSerializer.Deserialize(json, typeInfo);
	}
}


