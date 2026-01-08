namespace Ngaq.Core.Tools.JsonMap;

using Tsinswreng.CsTools;
using D = Dictionary<str, obj?>;


public class SampleJsonMap{
	protected static SampleJsonMap? _Inst = null;
	public static SampleJsonMap Inst => _Inst??= new SampleJsonMap();

	public UiJsonMap UiJsonMap = new();
	public UiJsonMapItem ItemUser=new UiJsonMapItem{
		Type = EJsonValueType.String,
		DisplayName = new("名"),
		Descr = new("用户名，长度不超过32个字符，随便你起"),
	};


	public SampleJsonMap(){
		UiJsonMap.PathToUiMap = MkPathToUiMap();
		UiJsonMap.Raw = MkRaw();
	}

	IJsonNode MkRaw(){
		var d = new D{
			["User"] = new D{
				["Name"] = "Tsinswreng",
				["Age"] = 24,
				["Hobbies"] = new List<str>{"Singing", "Dancing", "Rap", "BasketBall"},
				["Contact"] = new D{
					["Email"] = "Tsinswreng@gmail.com",
				}
			},
			["System"] = new D{
				["OS"] = "Windows 10",
			}
		};
		return new JsonNode(d);
	}

	IDictionary<str, UiJsonMapItem> MkPathToUiMap(){
		var R = new Dictionary<str, UiJsonMapItem>{
			["User.Name"] = ItemUser,
			["User.Age"] = new UiJsonMapItem{
				DisplayName = new("年齡"),
				Descr = new("那麼首先能告訴我你的年齡嗎"),
			},
			["User.Hobbies[0]"] = new UiJsonMapItem{
				DisplayName = new("第一個愛好"),
				Descr = new("全民製作人們大家好"),
			},
			["System.OS"] = new UiJsonMapItem{
				DisplayName = new("系统信息"),
				Descr = new("系统相关信息"),
			},
		};
		foreach(var (k,v) in R){
			v.Path = k;
		}
		return R;
	}
}

