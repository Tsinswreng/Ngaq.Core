namespace Ngaq.Core.Service.Word.Learn_.Models;

public struct Word_LearnRecord{
	public IWordForLearn Word{get;set;}
	public LearnRecord LearnRecord{get;set;}
	public Word_LearnRecord(
		IWordForLearn Word
		,LearnRecord LearnRecord
	){
		this.Word=Word;
		this.LearnRecord=LearnRecord;
	}
}
