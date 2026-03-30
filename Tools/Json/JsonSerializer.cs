using Tsinswreng.CsTools;

namespace Ngaq.Core.Tools.Json;

public class AppJsonSerializer
	:IJsonSerializer
	,IDictJsonSerializer
{
	public static AppJsonSerializer Inst => field??=new();
	[Impl]
	public str Stringify<T>(T O){
		return JSON.Stringify(O);
	}

	[Impl]
	public T? Parse<T>(str Json){
		return JSON.Parse<T>(Json);
	}

	[Impl]
	public obj? Parse(str Json, Type Type){
		return JSON.Parse(Json, Type);
	}
	
	public obj? ToDictJson<T>(T O){
		var json = this.Stringify(O);
		var dict = ToolJson.JsonStrToDict(json);
		return dict;
	}
	public obj? FromDictJson(obj? DictJson, Type Type){
		if(DictJson is null){
			return null;
		}
		if(DictJson is IDictionary<str, obj?> dict){
			var json = ToolJson.DictToJson(dict);
			return this.Parse(json, Type);
		}
		if(DictJson is IList<obj?> list){
			var json = ToolJson.ItblToJson(list);
			return this.Parse(json, Type);
		}
		throw new NotSupportedException("DictJson should be a dictionary or a list.");
	}
	public T? FromDictJson<T>(obj? DictJson){
		return (T?)this.FromDictJson(DictJson, typeof(T));
	}
	
}
