namespace Ngaq.Core.Service.Parser.Model;
public interface I_WordBlock{
	/// <summary>
	/// 詞頭 對應WordFormId
	/// </summary>
	public I_StrSegment? Head{get;set;}
	/// <summary>
	/// body蜮不連續、可被prop打斷、故用IList洏不用單個I_StrSegment
	/// 對應Mean
	/// </summary>
	public IList<I_StrSegment> Body{get;set;}
	public IList<I_Prop> Props{get;set;}
}

public struct WordBlock : I_WordBlock{
	//每個結構必帶無參構造器、縱不手動顯式定義。
	//但若不手動顯式定義無參構造器、則字段芝直接被賦值㕥初始化者 則不被初始化
	//[Obsolete("don't call no-param constructor")]
	public WordBlock(){}
	public WordBlock(I_StrSegment head){
		this.Head = head;
	}
	public I_StrSegment? Head{get;set;}
	public IList<I_StrSegment> Body{get;set;} = new List<I_StrSegment>();
	public IList<I_Prop> Props{get;set;} = new List<I_Prop>();
}
