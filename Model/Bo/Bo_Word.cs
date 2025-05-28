using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Tools;
using Ngaq.Core.Tools.Algo;

namespace Ngaq.Core.Model.Bo;

public class BoWord: IHasId<IdWord>{

	public PoWord PoWord{get;set;} = new PoWord();
	public IList<PoKv> Props{get;set;} = new List<PoKv>();
	public IList<PoLearn> Learns{get;set;} = new List<PoLearn>();

	public IdWord Id{
		get{return PoWord.Id;}
		set{PoWord.Id = (IdWord)value;}
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
			prop.FKeyUInt128 = z.PoWord.Id.Value;
		}
		foreach(var learn in z.Learns){
			// if(learn.Id.Value == 0){
			// 	learn.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			learn.FKeyUInt128 = z.PoWord.Id.Value;
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

public static class ExtnBoWord{
	/// <summary>
	/// 按詞頭對諸Bo詞分組
	/// 若入ʹ諸詞 非皆屬同一語 則拋錯
	/// </summary>
	/// <param name="BoWords"></param>
	/// <returns></returns>
	/// <exception cref="ErrArg"></exception>
	public static IDictionary<str, IList<BoWord>> GroupByWordFormOfSameLang(
		this IEnumerable<BoWord> BoWords
	){
		// var Dict = BoWords.GroupBy(w=>w.PoWord.WordFormId)
		// 	.ToDictionary(g=>g.Key, g=>(IList<BoWord>)[.. g])//  g=>g.ToList() -> [..g]
		// ;
		// return Dict;
		var Dict = new Dictionary<str, IList<BoWord>>();
		str Lang = "";
		var i = 0;
		foreach(var BoWord in BoWords){
			if(i == 0){
				Lang = BoWord.PoWord.Lang;
			}
			if(BoWord.PoWord.Lang != Lang){
				throw new ErrArg("BoWord.PoWord.Lang != Lang");
			}
			if(Dict.TryGetValue(BoWord.PoWord.Head, out var List)){
				List.Add(BoWord);
			}else{
				Dict[BoWord.PoWord.Head] = [BoWord];
			}
			// if(!Dict.ContainsKey(BoWord.PoWord.WordFormId)){
			// 	Dict[BoWord.PoWord.WordFormId] = [BoWord];
			// }else{
			// 	Dict[BoWord.PoWord.WordFormId].Add(BoWord);
			// }
			i++;
		}
		return Dict;
	}
}
