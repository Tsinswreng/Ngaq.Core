using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Tools;
using Ngaq.Core.Tools.Algo;

namespace Ngaq.Core.Model.Bo;

public class Bo_Word: IHasId<IdWord>{

	public Po_Word Po_Word{get;set;} = new Po_Word();
	public IList<Po_Kv> Props{get;set;} = new List<Po_Kv>();
	public IList<Po_Learn> Learns{get;set;} = new List<Po_Learn>();

	public IdWord Id{
		get{return Po_Word.Id;}
		set{Po_Word.Id = (IdWord)value;}
	}

	public Bo_Word AssignId(){
		var z = this;
		// if(z.Po_Word.Id.Value == 0){
		// 	z.Po_Word.Id = new Id_Word(IdTool.NewUlid_UInt128());
		// }
		foreach(var prop in z.Props){
			// if(prop.Id.Value == 0){
			// 	prop.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			prop.FKey_UInt128 = z.Po_Word.Id.Value;
		}
		foreach(var learn in z.Learns){
			// if(learn.Id.Value == 0){
			// 	learn.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			learn.FKey_UInt128 = z.Po_Word.Id.Value;
		}
		return z;
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
