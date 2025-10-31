using System.Text.Json;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Tools;

namespace Ngaq.Core.Infra;

/// <summary>
/// 除IWebAns<obj>外 他者勿用、緣不支持AOT下json序列化
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IWebAns<T>{
	public T? Data{get;set;}
	public IList<IAppErrView>? Errors{get;set;}
}

public class WebAns<T>:IWebAns<T>{
	public T? Data{get;set;}
	public IList<IAppErrView>? Errors{get;set;}
}

public class WebAns:WebAns<obj>{
	public static IWebAns<obj> Mk(obj? Data, IList<IAppErrView>? Errors=null){
		return new WebAns<obj>(){
			Data = Data,
			Errors = Errors,
		};
	}
}

public static class ExtnWebAns{
	// public static str ToJson<T>(this IWebAns<T> z){

	// }

}
