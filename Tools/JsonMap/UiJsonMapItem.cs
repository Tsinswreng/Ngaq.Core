namespace Ngaq.Core.Tools.JsonMap;
public class UiJsonMapItem{

	/// <summary>
	/// 如foo.bar[0].baz
	/// </summary>
	public str Path{get;set;} = "";
	public EJsonValueType Type{get;set;} = EJsonValueType.Unknown;
	public EValueMapper ValueMapper{get;set;} = EValueMapper.None;
	public UiText? DisplayName{get;set;}
	public UiText? Descr{get;set;}
}
