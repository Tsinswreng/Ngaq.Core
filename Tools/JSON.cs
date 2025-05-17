using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Ngaq.Core.Infra;
namespace TeQuaero.Shared.Util;

public static class JSON {

	static JsonSerializerOptions Opt = new JsonSerializerOptions{
		//WriteIndented = true
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 允許原樣輸出
		,PropertyNamingPolicy = null  // 关闭命名策略
		,TypeInfoResolver = AppJsonCtx.Default
	};

	public static str stringify<T>(
		T o
		,JsonTypeInfo? jsonTypeInfo = null
	){
		if(jsonTypeInfo == null){
			var ans = JsonSerializer.Serialize(o, Opt);
			return ans;
		}
		return JsonSerializer.Serialize(o, jsonTypeInfo);
	}

	public static T? parse<T>(
		str json
		,JsonTypeInfo<T>? jsonTypeInfo = null
	){
		if(jsonTypeInfo == null){
			return JsonSerializer.Deserialize<T>(json, Opt);
		}
		return JsonSerializer.Deserialize<T>(json, jsonTypeInfo);
	}
}


