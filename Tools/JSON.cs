using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Ngaq.Core.Infra;
using Ngaq.Core.Tools.Json;
namespace Ngaq.Core.Tools;


public static class JSON {
	
	/// 縱Opt中指定了TypeInfoResolver亦不效、肰直ᵈ傳TypeInfo又不可兼傳Opt。故需把選項加于appJsonCtxʹ註解
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

	public static string Stringify<T>(T o){
		// ✅ 使用 AppJsonCtx 提供的 type info
		var typeInfo = AppJsonCtx.Inst.GetTypeInfo(typeof(T)) as JsonTypeInfo<T>;
		if (typeInfo == null){
			throw new InvalidOperationException($"Type {typeof(T)} is not registered in AppJsonCtx");
		}

		return JsonSerializer.Serialize(o, typeInfo);
	}

	public static T? Parse<T>(string json){
		// ✅ 使用 AppJsonCtx 提供的 type info
		var typeInfo = AppJsonCtx.Default.GetTypeInfo(typeof(T)) as JsonTypeInfo<T>;
		if (typeInfo == null){
			throw new InvalidOperationException($"Type {typeof(T)} is not registered in AppJsonCtx");
		}
		return JsonSerializer.Deserialize(json, typeInfo);
	}
	
	public static obj? Parse(string json, Type T){
		var typeInfo = AppJsonCtx.Default.GetTypeInfo(T);
		if (typeInfo == null){
			throw new InvalidOperationException($"Type {T} is not registered in AppJsonCtx");
		}
		return JsonSerializer.Deserialize(json, typeInfo);
	}
	
	
}


