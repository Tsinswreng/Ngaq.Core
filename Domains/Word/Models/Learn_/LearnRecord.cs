namespace Ngaq.Core.Domains.Word.Models.Learn_;

using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Word.Models.Po.Learn;



public partial struct LearnRecord
	:ILearnRecord
{
	[Impl]
	public ELearn Learn{get;set;}
	[Impl]
	public i64 UnixMs{get;set;} = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	public LearnRecord(ELearn Value){
		Learn = Value;
	}
}


public static class ExtnLearnRecord{
	public static ILearnRecord ToLearnRecord(
		this PoWordLearn PoLearn
	){
		var learn = PoLearn.LearnResult;
		var record = new LearnRecord(){
			UnixMs = PoLearn?.CreatedAt??throw new NullReferenceException()
			,Learn = learn
		};
		return record;
	}

	public static PoWordLearn ToPoLearn(
		this ILearnRecord z
		,IdWord? WordId = null
	){
		var R = new PoWordLearn();
		R.LearnResult = z.Learn;
		R.CreatedAt = z.UnixMs;
		if(WordId != null){
			R.WordId = WordId.Value;
		}
		return R;
	}
}
