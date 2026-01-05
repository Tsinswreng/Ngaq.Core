using Tsinswreng.CsTools;

namespace Ngaq.Core.Tools.JsonMap;

public class UiKvMap{
#if DEBUG
	public class Sample{
		public static IList<UiMapItem> Samples = [];
		static Sample(){
			{
				var o = new UiMapItem();
				Samples.Add(o);

			}
		}
	}
#endif
	public Version Version{get;set;} = new Version(1,0,0);//2026_0103_105821
	public IKvNode Raw{get;set;}
	public IKvNode? Schema{get;set;}
	public IDictionary<str, UiMapItem>? PathToUiMap{get;set;}
	public str? I18nLang{get;set;}// = "zh-CN";
/// <summary>
/*
		"en":{
			"DfltAddBonus":{
				"DisplayName": "...",
				"Descr": "Default add event bonus value."
			}
		},
		"zh":{
			"DfltAddBonus":{
				"Descr": "默認加事件加成的數值。"
			}
		}
 */
/// </summary>
	public IKvNode? I18n{get;set;}
}

[Doc(@$"

異ₐUI ʸʹ編輯器控件ˇ針對、需細分JsonValue之類型 如下。

複雜ₐ嵌套對象ˇ不支持。

需改複雜ₐ嵌套對象旹 宜新建{nameof(UiMapItem)}ⁿ用{nameof(UiMapItem.Path)}
精準定位至其簡單ₐ字段
")]
public enum EKvValueType{
	Unknown,
	String,
	Number,
	Boolean,
	Array,
	Object,
	StringArray,
	NumberArray,
	StringStringMap,
	NumberNumberMap,
	StringNumberMap,
	StringBooleanMap,
	NumberStringMap,
}

public class UiMapItem{

	/// <summary>
	/// 如foo.bar[0].baz
	/// </summary>
	public str Path{get;set;} = "";
	public EKvValueType Type{get;set;} = EKvValueType.Unknown;
	public EValueMapper ValueMapper{get;set;} = EValueMapper.None;
	public UiText? DisplayName{get;set;}
	public UiText? Descr{get;set;}
}

public enum EValueMapper{
	None,
	UnixMsToDate,
}

public enum EUiTextType{
	RawText,
	I18nKey,
}
public class UiText{
	public EUiTextType Type{get;set;}
	public str? Data{get;set;}
}

#if false
```json
{
	"Raw": {
		"AddCnt_Bonus": [0xff,0xfff,0xffff,0xfffff],
		"DfltAddBonus": 0xffffffff
	},
	"Schema": { //標準 Json Schema。用于驗證Raw。可選

	},
	"UiMap": [
		{
			"Path": "AddCnt_Bonus",
			"Type": "numberArr",
			"DisplayName": "加事件次數-加成數值",
			"Descr": "加事件次數-加成數值的數值陣列，用於計算加成的加成值。"
		},
		{
			"Path": "DfltAddBonus",//如果是深層的嵌套對象、就用正斜槓或點作分隔符
			"Type": "number",
			"DisplayName": {
				"Type": "RawText",
				"Data": "默認加事件加成",
			},
			"Descr": {
				"Type": "I18nKey",
				"Data": "DfltAddBonus.Descr"
			}
		},

	],
	"LangMap":{
		"en":{
			"DfltAddBonus":{
				"DisplayName": "...",
				"Descr": "Default add event bonus value."
			}
		},
		"zh":{
			"DfltAddBonus":{
				"Descr": "默認加事件加成的數值。"
			}
		}
	}

}

```
#endif
