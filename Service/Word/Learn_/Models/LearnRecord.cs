using Ngaq.Core.Model.Po.Learn;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public struct LearnRecord:ILearnRecord{
	public Learn Value{get;set;}
	public i64 Time{get;set;}
}


public static class ExtnLearnRecord{
	public static ILearnRecord ToLearnRecord(
		this PoLearn PoLearn
	){
		var learn = new Learn(PoLearn.VStr??"");
		var record = new LearnRecord(){
			Time = PoLearn.CreatedAt
			,Value = learn
		};
		return record;
	}
}
