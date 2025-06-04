using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;

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

	public static PoLearn ToPoLearn(
		this LearnRecord z
		,IdWord? WordId = null
	){
		var R = new PoLearn();
		R.SetStrToken(null, KeysProp.Inst.learn, z.Value);
		if(WordId!= null){
			R.FKeyUInt128 = WordId.Value;
		}
		return R;
	}
}
