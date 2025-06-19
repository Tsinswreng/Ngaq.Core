using Ngaq.Core.Word.Models.Po.Learn;
using Tsinswreng.CsCore.Tools.MultiDict;

namespace Ngaq.Core.Word.Models.Learn_;
public interface I_Learn_Records{
	/// <summary>
	/// 值 按日期排序
	/// </summary>
	public IDictionary<Learn, IList<ILearnRecord>> Learn_Records{get;set;}
	#if Impl
	= new Dictionary<Learn, IList<ILearnRecord>>();
	#endif
}


public static class ExtnI_Learn_Records{

	public static IDictionary<Learn, IList<ILearnRecord>> AddFromLearnRecords(
		this IDictionary<Learn, IList<ILearnRecord>> z
		,IEnumerable<ILearnRecord> LearnRecords
	){
		foreach(var LearnRecord in LearnRecords){
			var record = LearnRecord;
			z.AddInValues(
				record.Learn
				,record
			);
		}
		return z;
	}

	public static IDictionary<Learn, IList<ILearnRecord>> AddFromPoLearns(
		this IDictionary<Learn, IList<ILearnRecord>> z
		,IEnumerable<PoWordLearn> PoLearns
	){
		foreach(var PoLearn in PoLearns){
			var record = PoLearn.ToLearnRecord();
			z.AddInValues(
				record.Learn
				,record
			);
		}
		return z;
	}
}


