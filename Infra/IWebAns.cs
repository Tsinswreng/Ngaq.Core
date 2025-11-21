namespace Ngaq.Core.Infra;

using System.Text.Json;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Infra.IF;
using Tsinswreng.CsErr;

public static class ExtnWebAns2{
	extension(WebAns z){
		public static IWebAns<T> Deserialize<T>(str Json){
			using var doc = JsonDocument.Parse(Json);
			var root = doc.RootElement;
			// 1. 反序列化 Errors（始终用源生成器）
			IList<AppErrView>? errors = null;
			if (root.TryGetProperty(nameof(Errors), out var errEl) && errEl.ValueKind != JsonValueKind.Null){
				errors = errEl.Deserialize(AppJsonCtx.Default.IListAppErrView);
			}

			// 2. 反序列化 Data（按需用默认源生成器或调用方提供的选项）
			T? data = default;
			if (root.TryGetProperty(nameof(IWebAns<>.Data), out var dataEl) && dataEl.ValueKind != JsonValueKind.Null){
				//“AppJsonCtx”未包含“GetRequiredTypeInfo”的定义，并且找不到可接受第一个“AppJsonCtx”类型参数的可访问扩展方法“GetRequiredTypeInfo”(是否缺少 using 指令或程序集引用?)CS1061
				data = (T?)dataEl.Deserialize(AppJsonCtx.Default.GetTypeInfo(typeof(T))!);
			}

			var R = new WebAns<T>();
			R.Data = data;
			R.Errors = errors?.Select(x=>(IAppErrView)x).ToList();
			return R;
		}
	}

}
