using Tsinswreng.CsTools;

namespace Ngaq.Core.Tools.JsonMap;

public class JsonMap{
	public IKvNode Raw{get;set;}
	public IKvNode? Schema{get;set;}
	public str? I18nLang{get;set;}// = "zh-CN";
}

public enum EJsonValueType{
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

public class UiMap{
	/// <summary>
	/// 如foo.bar[0].baz
	/// </summary>
	public str Path{get;set;} = "";
	public EJsonValueType Type{get;set;} = EJsonValueType.Unknown;
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
	public str? Value{get;set;}
}
