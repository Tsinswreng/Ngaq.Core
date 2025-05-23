using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Tools;
using Ngaq.Core.Tools.Algo;

namespace Ngaq.Core.Model.Bo;

public class BoWord: IHasId<IdWord>{

	public PoWord Po_Word{get;set;} = new PoWord();
	public IList<PoKv> Props{get;set;} = new List<PoKv>();
	public IList<PoLearn> Learns{get;set;} = new List<PoLearn>();

	public IdWord Id{
		get{return Po_Word.Id;}
		set{Po_Word.Id = (IdWord)value;}
	}

	public BoWord AssignId(){
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
	public static IList<PoKv> DiffProps(
		IList<PoKv> PropsToAdd
		,IList<PoKv> ExistingProps
	){
		var diff = Algo.DiffListIntoMap(
			(IList<PoKv>)PropsToAdd, (IList<PoKv>)ExistingProps
			, (e)=> e.UpdatedAt ?? e.CreatedAt
		);
		List<PoKv> ans = [];
		foreach(var kvp in diff){
			ans.AddRange(kvp.Value);
		}
		return ans;
	}

}
