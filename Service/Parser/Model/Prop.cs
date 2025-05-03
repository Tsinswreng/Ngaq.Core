namespace Ngaq.Core.Service.Parser.Model;
public interface I_Prop{
	public I_StrSegment Key{get;set;}
	public I_StrSegment Value{get;set;}
}

public struct Prop : I_Prop{
	public Prop(){}
	public I_StrSegment Key{get;set;} // 允許褈複key
	public I_StrSegment Value{get;set;}
}
