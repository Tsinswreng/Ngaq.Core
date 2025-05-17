using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Tools.Algo;

namespace Ngaq.Core.Model.Bo;

public class Bo_Word: I_Id<Id_Word>{

	public Po_Word Po_Word{get;set;} = new Po_Word();
	public IList<Po_Kv> Props{get;set;} = new List<Po_Kv>();
	public IList<Po_Learn> Learns{get;set;} = new List<Po_Learn>();

	public Id_Word Id{
		get{return Po_Word.Id;}
		set{Po_Word.Id = (Id_Word)value;}
	}

	/**
	 * 以ut潙準取差集
	 * w1有洏w2無 者
	 * @param w1 待加者
	 * @param w2 已有者
	 * @returns 未加過之prop
	 */
	public static IList<Po_Kv> DiffProps(
		IList<Po_Kv> PropsToAdd
		,IList<Po_Kv> ExistingProps
	){
		var diff = Algo.DiffListIntoMap(
			(IList<Po_Kv>)PropsToAdd, (IList<Po_Kv>)ExistingProps
			, (e)=> e.UpdatedAt ?? e.CreatedAt
		);
		List<Po_Kv> ans = [];
		foreach(var kvp in diff){
			ans.AddRange(kvp.Value);
		}
		return ans;
	}

}
