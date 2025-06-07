using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Tools;
using Ngaq.Core.Tools.Algo;
using Tsinswreng.CsCore.Tools;

namespace Ngaq.Core.Model.Bo;

public class JnWord
	:IPoWord
{
	// public static str Debug(BoWord boWord){
	// 	if(boWord.Head == "interrogative"){
	// 		System.Console.WriteLine(boWord);
	// 		var means = boWord.Props.Select(p=>p).Where(w=>w.KStr=="description")
	// 		.Select(p=>p.VStr)
	// 		.ToList();
	// 		var meanStr = str.Join("\n", means);
	// 		System.Console.WriteLine(meanStr);//t
	// 		return meanStr;
	// 	}
	// 	return "";
	// }

	public JnWord(){}
	public JnWord(PoWord PoWord, IList<PoKv> Props, IList<PoLearn> Learns){
		this.PoWord = PoWord;
		this.Props = Props;
		this.Learns = Learns;
	}

	public PoWord PoWord{get;set;} = new PoWord();
	public IList<PoKv> Props{get;set;} = new List<PoKv>();
	public IList<PoLearn> Learns{get;set;} = new List<PoLearn>();

	public IdWord Id{
		get{return PoWord.Id;}
		set{
			PoWord.Id = (IdWord)value;
			AssignId();
		}
	}

	public IdUser Owner{
		get{return PoWord.Owner;}
		set{PoWord.Owner = value;}
	}

	public str Lang{
		get{return PoWord.Lang;}
		set{PoWord.Lang = value;}
	}

	public str Head{
		get{return PoWord.Head;}
		set{PoWord.Head = value;}
	}


	#region IPoBase
	public i64 InsertedAt{
		get{return PoWord.InsertedAt;}
		set{PoWord.InsertedAt = value;}
	}

	public i64? CreatedAt{
		get{return PoWord.CreatedAt;}
		set{PoWord.CreatedAt = value;}
	}

	public IdUser? CreatedBy{
		get{return PoWord.CreatedBy;}
		set{PoWord.CreatedBy = value;}
	}
	/// <summary>
	/// 當關聯ʹ他表 更新旹、亦當更新此字段
	/// </summary>
	public i64? UpdatedAt{
		get{return PoWord.UpdatedAt;}
		set{PoWord.UpdatedAt = value;}
	}
	public IdUser? LastUpdatedBy{
		get{return PoWord.LastUpdatedBy;}
		set{PoWord.LastUpdatedBy = value;}
	}
	public i64 Status{
		get{return PoWord.Status;}
		set{PoWord.Status = value;}
	}
	#endregion IPoBase


/// <summary>
/// 把諸資產之外鍵設潙主Word之id
/// </summary>
/// <returns></returns>
	public JnWord AssignId(){
		var z = this;
		// if(z.Po_Word.Id.Value == 0){
		// 	z.Po_Word.Id = new Id_Word(IdTool.NewUlid_UInt128());
		// }
		foreach(var prop in z.Props){
			// if(prop.Id.Value == 0){
			// 	prop.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			prop.WordId = z.PoWord.Id;
		}
		foreach(var learn in z.Learns){
			// if(learn.Id.Value == 0){
			// 	learn.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			learn.WordId = z.PoWord.Id.Value;
		}
		return z;
	}

	public PoLearn AddLearn(PoLearn Learn){
		Learn.WordId = PoWord.Id.Value;
		Learns.Add(Learn);
		return Learn;
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
		var diff = Algo.DiffListIntoDict(
			(IList<PoKv>)PropsToAdd, (IList<PoKv>)ExistingProps
			, (e)=> e.UpdatedAt ?? e.CreatedAt??throw new FatalLogicErr("CreatedAt should not be null")
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
	public static IDictionary<str, IList<JnWord>> GroupByHeadOfSameLang(
		this IEnumerable<JnWord> BoWords
	){
		// var Dict = BoWords.GroupBy(w=>w.PoWord.WordFormId)
		// 	.ToDictionary(g=>g.Key, g=>(IList<BoWord>)[.. g])//  g=>g.ToList() -> [..g]
		// ;
		// return Dict;
		var Dict = new Dictionary<str, IList<JnWord>>();
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
			i++;
		}
		return Dict;
	}


	public static IDictionary<Head_Lang, IList<JnWord>> GroupByLangHead(
		this IEnumerable<JnWord> BoWords
	){
		var Dict = new Dictionary<Head_Lang, IList<JnWord>>();
		foreach(var BoWord in BoWords){
			// if(BoWord.Head == "interrogative"){//t
			// 	BoWord.Debug(BoWord);
			// }//-
			var lang_head = new Head_Lang{
				Lang = BoWord.PoWord.Lang
				,Head = BoWord.PoWord.Head
			};
			if(Dict.TryGetValue(lang_head, out var List)){
				List.Add(BoWord);
			}else{
				Dict[lang_head] = [BoWord];
			}
		}
		return Dict;
	}

	public static bool IsSameUserWord(
		this IPoWord W1
		,IPoWord W2
	){
		if(W1.Head != W2.Head){
			return false;
		}
		if(W1.Lang != W2.Lang){
			return false;
		}
		if(W1.Owner != W2.Owner){
			return false;
		}
		return true;
	}


/// <summary>
/// CreatedAt取更早者
/// UpdatedAt取最晚者
/// </summary>
/// <param name="BoWords"></param>
/// <returns></returns>
/// <exception cref="ErrArg"></exception>
	public static JnWord? MergeSameWords(
		this IEnumerable<JnWord> BoWords
	){

		JnWord R = null!;
		foreach(var (BoWord, i) in BoWords.IPairs()){
			if(i == 0){
				R = BoWord;
			}else{
				if(!R.IsSameUserWord(BoWord)){
					throw new ErrArg("!R.IsSameUserWord(BoWord)");
				}
				if(R.InsertedAt > BoWord.InsertedAt){
					R.InsertedAt = BoWord.InsertedAt;
				}
				if(R.CreatedAt > BoWord.CreatedAt){
					R.CreatedAt = BoWord.CreatedAt;
				}
				if(R.UpdatedAt < BoWord.UpdatedAt){
					R.UpdatedAt = BoWord.UpdatedAt;
				}
				if(R.LastUpdatedBy == null && BoWord.LastUpdatedBy != null){
					R.LastUpdatedBy = BoWord.LastUpdatedBy;
				}
				R.Props.AddRange(BoWord.Props);
				R.Learns.AddRange(BoWord.Learns);
			}
		}//~foreach
		return R;
	}

}
