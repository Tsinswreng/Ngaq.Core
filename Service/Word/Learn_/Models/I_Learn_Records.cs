using Ngaq.Core.Model.Po.Learn;
using Tsinswreng.CsCore.Tools.MultiDict;

namespace Ngaq.Core.Service.Word.Learn_.Models;
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
	public static IDictionary<Learn, IList<ILearnRecord>> FromPoLearns(
		this IDictionary<Learn, IList<ILearnRecord>> z
		,IEnumerable<PoLearn> PoLearns
	){
		foreach(var PoLearn in PoLearns){
			var record = PoLearn.ToLearnRecord();
			z.AddInValues(
				record.Value
				,record
			);
		}
		return z;
	}
}


