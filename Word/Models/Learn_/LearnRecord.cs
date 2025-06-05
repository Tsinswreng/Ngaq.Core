using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;

namespace Ngaq.Core.Word.Models.Learn_;

public struct LearnRecord
	:ILearnRecord
{
	public Learn Learn{get;set;}
	public i64 UnixMs{get;set;} = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	public LearnRecord(Learn Value){
		Learn = Value;
	}
}


public static class ExtnLearnRecord{
	public static ILearnRecord ToLearnRecord(
		this PoLearn PoLearn
	){
		var learn = new Learn(PoLearn.VStr??"");
		var record = new LearnRecord(){
			UnixMs = PoLearn.CreatedAt
			,Learn = learn
		};
		return record;
	}

	public static PoLearn ToPoLearn(
		this ILearnRecord z
		,IdWord? WordId = null
	){
		var R = new PoLearn();
		R.SetStrToken(null, KeysProp.Inst.learn, z.Learn);
		if(WordId!= null){
			R.FKeyUInt128 = WordId.Value;
		}
		return R;
	}
}
