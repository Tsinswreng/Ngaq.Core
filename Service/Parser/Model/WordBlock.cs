namespace Ngaq.Core.Service.Parser.Model;
public interface I_WordBlock{
	public I_StrSegment Head{get;set;}
	//body蜮不連續、可被prop打斷、故用IList洏不用單個I_StrSegment
	public IList<I_StrSegment> Body{get;set;}
	public IList<I_Prop> Props{get;set;}
}

public struct WordBlock : I_WordBlock{
	public WordBlock(){}
	public WordBlock(I_StrSegment head){
		this.Head = head;
	}
	public I_StrSegment Head{get;set;}
	public IList<I_StrSegment> Body{get;set;} = new List<I_StrSegment>();
	public IList<I_Prop> Props{get;set;} = new List<I_Prop>();
}