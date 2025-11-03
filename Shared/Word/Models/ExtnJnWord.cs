namespace Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Word.Models;
using Tsinswreng.CsTools;

public static class ExtnJnWord{
	public static JnWord AsOrToJnWord(this IJnWord z){
		if(z is JnWord j){
			return j;
		}
		return new JnWord(z.Word, z.Props, z.Learns);
	}
	public static IJnWord AsSimpleJnWord(this JnWord z){
		return (IJnWord)z;
	}

	/// <summary>
	/// 按詞頭對諸詞分組
	/// 若入ʹ諸詞 非皆屬同一語 則拋錯
	/// 返ʹ值: 詞頭->諸詞芝厥語語詞頭皆同者
	/// </summary>
	public static IDictionary<str, IList<IJnWord>> GroupByHeadOfSameLang(
		this IEnumerable<IJnWord> JnWords
	){
		// var Dict = BoWords.GroupBy(w=>w.PoWord.WordFormId)
		// 	.ToDictionary(g=>g.Key, g=>(IList<BoWord>)[.. g])//  g=>g.ToList() -> [..g]
		// ;
		// return Dict;
		var Dict = new Dictionary<str, IList<IJnWord>>();
		str Lang = "";
		var i = 0;
		foreach(var JWord in JnWords){
			if(i == 0){
				Lang = JWord.Word.Lang;
			}
			if(JWord.Word.Lang != Lang){
				throw ItemsErr.Word.__NotBelongToLang__
				.ToErr(JWord.Id_(), Lang)
				.AddDebugArgs(JWord);
			}
			if(Dict.TryGetValue(JWord.Word.Head, out var List)){
				List.Add(JWord);
			}else{
				Dict[JWord.Word.Head] = [JWord];
			}
			i++;
		}
		return Dict;
	}


	/// <summary>
	/// 按(詞頭,語言)對諸詞分組
	/// 返ʹ值: (詞頭,語言)->諸詞芝厥語語詞頭皆同者
	/// </summary>
	public static IDictionary<Head_Lang, IList<IJnWord>> GroupByLangHead(
		this IEnumerable<IJnWord> JnWords
	){
		var Dict = new Dictionary<Head_Lang, IList<IJnWord>>();
		foreach(var JWord in JnWords){
			var lang_head = new Head_Lang{
				Lang = JWord.Word.Lang
				,Head = JWord.Word.Head
			};
			if(Dict.TryGetValue(lang_head, out var List)){
				List.Add(JWord);
			}else{
				Dict[lang_head] = [JWord];
			}
		}
		return Dict;
	}

	/// <summary>
	/// 只比詞頭 語言 與擁者
	/// </summary>
	/// <param name="W1"></param>
	/// <param name="W2"></param>
	/// <returns></returns>
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

	//有蠹 2個Prop芝CreatedAtˋ同者 diff 一個Prop旹 diff不出 只適用于新增單詞
	public static IJnWord? DiffByTime(
		this IJnWord z
		,IJnWord Other
	){
		IJnWord? R=null;
		z.DiffByTime(Other, ref R);
		return R;
	}

	/// <summary>
	//有蠹 2個Prop芝CreatedAtˋ同者 diff 一個Prop旹 diff不出 只適用于新增單詞
	/// Other 合入 z 返R
	/// 無需合併旹返null
	/// 非同ʹ詞旹拋錯
	/// </summary>
	public static IJnWord? DiffByTime(
		this IJnWord z
		,IJnWord Other
		,ref IJnWord? R
	){
		var z_ = z.AsOrToJnWord();
		var Other_ = Other.AsOrToJnWord();
		if(!z_.IsSameUserWord(Other_)){
			throw ItemsErr.Word.__And__IsNotSameUserWord
			.ToErr(z.Id_(), Other.Id_())
			.AddDebugArgs(z,Other);
		}
		if(z.IsSynced(Other)){
			return null;
		}
		var DiffedProps = JnWord.DiffPropsByTime(z.Props, Other.Props);
		var DiffedLearns = JnWord.DiffLearnsByTime(z.Learns, Other.Learns);
		R??=new JnWord();
		R.Word = z.Word;
		R.Props = DiffedProps;
		R.Learns = DiffedLearns;
		R.UpdTimeOfSelfContrastToOther(Other);
		return R;
	}

/// <summary>
/// CreatedAt取更早者
/// UpdatedAt取最晚者
/// </summary>
/// <param name="z"></param>
/// <param name="Other_"></param>
/// <returns></returns>
/// <exception cref="ErrArg"></exception>
	public static IJnWord UpdTimeOfSelfContrastToOther(
		this IJnWord z
		,IJnWord Other
	){
		var jnWord = z.AsOrToJnWord();
		var other_ = Other.AsOrToJnWord();
		if(!jnWord.IsSameUserWord(other_)){
			throw new ErrArg("!R.IsSameUserWord(BoWord)");
		}
		if(jnWord.DbCreatedAt > other_.DbCreatedAt){
			jnWord.DbCreatedAt = other_.DbCreatedAt;
		}
		if(jnWord.BizCreatedAt > other_.BizCreatedAt){
			jnWord.BizCreatedAt = other_.BizCreatedAt;
		}
		if(jnWord.BizUpdatedAt < other_.BizUpdatedAt){
			jnWord.BizUpdatedAt = other_.BizUpdatedAt;
		}
		// if(R.LastUpdatedBy == null && Other.LastUpdatedBy != null){
		// 	R.LastUpdatedBy = Other.LastUpdatedBy;
		// }
		return jnWord;
	}


	/// <summary>
	/// 無去褈ˌᵈ併ᵣ諸詞ˇ
	/// 用于併ᵣ文本詞表ᙆʹ待加ʹ諸詞
	/// JnWords 須潙同一詞 否則拋錯
	/// </summary>
	/// <exception cref="ErrArg"></exception>
	public static IJnWord? NoDiffMergeSameWords(
		this IEnumerable<IJnWord> JnWords
	){
		JnWord R = null!;
		foreach(var (i, SimpleJWord) in JnWords.Index()){
			var jWord = SimpleJWord.AsOrToJnWord();
			if(i == 0){
				R = jWord.AsOrToJnWord();
			}else{
				if(!R.IsSameUserWord(jWord)){
					throw new ErrArg("!IsSameUserWord(R, JWord)");
				}
				R.UpdTimeOfSelfContrastToOther(jWord);
				R.Props.AddRange(jWord.Props);
				R.Learns.AddRange(jWord.Learns);
			}
		}//~foreach
		return R;
	}

	public static IJnWord SortByCreatedAtAsc(
		this IJnWord z
	){
		z.Props.Sort((a,b)=>a.BizCreatedAt.Value.CompareTo(b.BizCreatedAt));
		z.Learns.Sort((a,b)=>a.BizCreatedAt.Value.CompareTo(b.BizCreatedAt));
		return z;
	}

	public static bool IsSynced(
		this IJnWord Other
		,IJnWord Existing
	){
		var Other_ = Other.AsOrToJnWord();
		var Existing_ = Existing.AsOrToJnWord();
		if(!Other_.IsSameUserWord(Existing_)){
			throw new ErrArg("!IsSameUserWord(z, Other)");
		}
		if(//視潙同一詞 返null
			Other_.BizCreatedAt == Existing_.BizCreatedAt
			&& Other_.BizUpdatedAt == Existing_.BizUpdatedAt
			&& Other_.Props.Count == Existing_.Props.Count
			&& Other_.Learns.Count == Existing_.Learns.Count
		){
			return true;
		}
		return false;
	}

	/// <summary>
	/// 把諸資產之外鍵設潙主Word之id
	/// </summary>
	/// <returns></returns>
	public static TSelf EnsureForeignId<TSelf>(this TSelf z)
		where TSelf : IJnWord
	{
		// if(z.Po_Word.Id.Value == 0){
		// 	z.Po_Word.Id = new Id_Word(IdTool.NewUlid_UInt128());
		// }
		foreach(var prop in z.Props){
			// if(prop.Id.Value == 0){
			// 	prop.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			prop.WordId = z.Word.Id;
		}
		foreach(var learn in z.Learns){
			// if(learn.Id.Value == 0){
			// 	learn.Id = new Id_Kv(IdTool.NewUlid_UInt128());
			// }
			learn.WordId = z.Word.Id.Value;
		}
		return z;
	}


	// public static DtoWordDiff? Diff(
	// 	this JnWord Other
	// 	,JnWord Existing
	// ){
	// 	if(!Other.IsSameUserWord(Existing)){
	// 		throw new ErrArg("!IsSameUserWord(z, Other)");
	// 	}
	// 	if(//視潙同一詞 返null
	// 		Other.CreatedAt == Existing.CreatedAt
	// 		&& Other.UpdatedAt == Existing.UpdatedAt
	// 		&& Other.Props.Count == Existing.Props.Count
	// 		&& Other.Learns.Count == Existing.Learns.Count
	// 	){
	// 		return null;
	// 	}

	// 	var DiffedProps = JnWord.DiffProps(Other.Props, Existing.Props);
	// 	var DiffedLearns = JnWord.DiffLearns(Other.Learns, Existing.Learns);
	// 	var R = new DtoWordDiff(){
	// 		PoWordLearns = DiffedLearns
	// 		,PoWordProps = DiffedProps
	// 	};
	// 	return R;
	// }
}


