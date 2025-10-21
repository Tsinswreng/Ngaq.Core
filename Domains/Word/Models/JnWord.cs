#define Impl
namespace Ngaq.Core.Domains.Word.Models;

using Ngaq.Core.Domains.User.Models.Po;
using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Domains.Word.Models.Po.Kv;
using Ngaq.Core.Domains.Word.Models.Po.Word;
using Ngaq.Core.Infra;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Tools.Algo;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Po.Learn;
using Tsinswreng.CsTools;

/// 嚴格對應數據庫ʹ實體ʹ聚合
/// 專用于json序列化
/// 不含字段如
/// 	[Impl]
///	public IdWord Id{
///		get{return Word.Id;}
///		set{
///			Word.Id = value;
///			AssignId();
///		}
///	}
public interface ISimpleJnWord: IAppSerializable{
	public PoWord Word{get;set;}
	public IList<PoWordProp> Props{get;set;}
	public IList<PoWordLearn> Learns{get;set;}
}



public partial class JnWord
	:ISimpleJnWord, IPoWord, IAppSerializable
{
	[Impl(typeof(IPoWord))]
	public object ShallowCloneSelf()
#if Impl
	{
		return MemberwiseClone();
	}
#endif

	public JnWord(){}
	public JnWord(PoWord PoWord, IList<PoWordProp> Props, IList<PoWordLearn> Learns){
		Word = PoWord;
		this.Props = Props;
		this.Learns = Learns;
	}

	[Impl(typeof(ISimpleJnWord))]
	public PoWord Word{get;set;} = new PoWord();
	[Impl(typeof(ISimpleJnWord))]
	public IList<PoWordProp> Props{get;set;} = new List<PoWordProp>();
	[Impl(typeof(ISimpleJnWord))]
	public IList<PoWordLearn> Learns{get;set;} = new List<PoWordLearn>();
	[Impl]
	public IdWord Id{
		get{return Word.Id;}
		set{
			Word.Id = value;
			EnsureForeignId();
		}
	}

	[Impl]
	public IdUser Owner{
		get{return Word.Owner;}
		set{Word.Owner = value;}
	}
	[Impl]
	public str Lang{
		get{return Word.Lang;}
		set{Word.Lang = value;}
	}
	[Impl]
	public str Head{
		get{return Word.Head;}
		set{Word.Head = value;}
	}

	[Impl(typeof(IPoWord))]
	public Tempus StoredAt{
		get{return Word.StoredAt;}
		set{Word.StoredAt = value;}
	}

	#region IPoBase

	[Impl]
	public IdDel DelAt{get;set;}

	[Impl]
	public Tempus DbCreatedAt{
		get{return Word.DbCreatedAt;}
		set{Word.DbCreatedAt = value;}
	}

	[Impl]
	public Tempus CreatedAt{
		get{return Word.CreatedAt;}
		set{Word.CreatedAt = value;}
	}

	/// <summary>
	/// 當關聯ʹ他表 更新旹、亦當更新此字段
	/// </summary>
	[Impl]
	public Tempus? UpdatedAt{
		get{return Word.UpdatedAt;}
		set{Word.UpdatedAt = value;}
	}
	[Impl]
	public Tempus? DbUpdatedAt{
		get{return Word.DbUpdatedAt;}
		set{Word.DbUpdatedAt = value;}
	}
	[Impl]
	public IdUser? CreatedBy{
		get{return Word.CreatedBy;}
		set{Word.CreatedBy = value;}
	}
	[Impl]
	public IdUser? LastUpdatedBy{
		get{return Word.LastUpdatedBy;}
		set{Word.LastUpdatedBy = value;}
	}
	// [Impl]
	// public PoStatus Status{
	// 	get{return Word.Status;}
	// 	set{Word.Status = value;}
	// }
	#endregion IPoBase


	/// <summary>
	/// 把諸資產之外鍵設潙主Word之id
	/// </summary>
	/// <returns></returns>
	public JnWord EnsureForeignId(){
		var z = this;
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

	public PoWordLearn AddLearn(PoWordLearn Learn){
		Learn.WordId = Word.Id.Value;
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
	//有蠹 2個Prop芝CreatedAtˋ同者 diff 一個Prop旹 diff不出 只適用于新增單詞
	public static IList<PoWordProp> DiffPropsByTime(
		IList<PoWordProp> PropsToAdd
		,IList<PoWordProp> ExistingProps
	){
		var diff = Algo.DiffListIntoDict(
			PropsToAdd, ExistingProps
			, (e)=> e.UpdatedAt ?? e.CreatedAt
		);
		List<PoWordProp> ans = [];
		foreach(var (Time,Props) in diff){
			ans.AddRange(Props);
		}
		return ans;
	}

	/// <summary>
	/// //有蠹 2個Prop芝CreatedAtˋ同者 diff 一個Prop旹 diff不出 只適用于新增單詞
	/// </summary>
	public static IList<PoWordLearn> DiffLearnsByTime(
		IList<PoWordLearn> LearnsOfNeo
		,IList<PoWordLearn> ExistingLearns
	){
		var diff = Algo.DiffListIntoDict(
			LearnsOfNeo, ExistingLearns
			,(e)=> e.Time_()
		);
		return diff.SelectMany(Time_Learns=>Time_Learns.Value).ToList();
	}

}

public static class ExtnJnWord{
	/// <summary>
	/// 按詞頭對諸Jn詞分組
	/// 若入ʹ諸詞 非皆屬同一語 則拋錯
	/// </summary>
	/// <param name="JnWords"></param>
	/// <returns></returns>
	/// <exception cref="ErrArg"></exception>
	public static IDictionary<str, IList<JnWord>> GroupByHeadOfSameLang(
		this IEnumerable<JnWord> JnWords
	){
		// var Dict = BoWords.GroupBy(w=>w.PoWord.WordFormId)
		// 	.ToDictionary(g=>g.Key, g=>(IList<BoWord>)[.. g])//  g=>g.ToList() -> [..g]
		// ;
		// return Dict;
		var Dict = new Dictionary<str, IList<JnWord>>();
		str Lang = "";
		var i = 0;
		foreach(var JWord in JnWords){
			if(i == 0){
				Lang = JWord.Word.Lang;
			}
			if(JWord.Word.Lang != Lang){
				throw new ErrArg("JWord.PoWord.Lang != Lang");
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


	public static IDictionary<Head_Lang, IList<JnWord>> GroupByLangHead(
		this IEnumerable<JnWord> JnWords
	){
		var Dict = new Dictionary<Head_Lang, IList<JnWord>>();
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
	public static JnWord? DiffByTime(
		this JnWord z
		,JnWord Other
	){
		JnWord? R=null;
		z.DiffByTime(Other, ref R);
		return R;
	}

	/// <summary>
	//有蠹 2個Prop芝CreatedAtˋ同者 diff 一個Prop旹 diff不出 只適用于新增單詞
	/// Other 合入 z 返R
	/// 無需合併旹返null
	/// 非同ʹ詞旹拋錯
	/// </summary>
	/// <param name="z"></param>
	/// <param name="Other"></param>
	/// <param name="R"></param>
	/// <returns></returns>
	/// <exception cref="ErrArg"></exception>
	public static JnWord? DiffByTime(
		this JnWord z
		,JnWord Other
		,ref JnWord? R
	){
		if(!z.IsSameUserWord(Other)){
			throw new ErrArg("!z.IsSameUserWord(Other)");
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
/// <param name="R"></param>
/// <param name="Other"></param>
/// <returns></returns>
/// <exception cref="ErrArg"></exception>
	public static JnWord UpdTimeOfSelfContrastToOther(
		this JnWord R
		,JnWord Other
	){
		if(!R.IsSameUserWord(Other)){
			throw new ErrArg("!R.IsSameUserWord(BoWord)");
		}
		if(R.DbCreatedAt > Other.DbCreatedAt){
			R.DbCreatedAt = Other.DbCreatedAt;
		}
		if(R.CreatedAt > Other.CreatedAt){
			R.CreatedAt = Other.CreatedAt;
		}
		if(R.UpdatedAt < Other.UpdatedAt){
			R.UpdatedAt = Other.UpdatedAt;
		}
		if(R.LastUpdatedBy == null && Other.LastUpdatedBy != null){
			R.LastUpdatedBy = Other.LastUpdatedBy;
		}
		return R;
	}


	/// <summary>
	/// 無去褈ˌᵈ併ᵣ諸詞ˇ
	/// 用于併ᵣ文本詞表ᙆʹ待加ʹ諸詞
	/// JnWords 須潙同一詞 否則拋錯
	/// </summary>
	/// <exception cref="ErrArg"></exception>
	public static JnWord? NoDiffMergeSameWords(
		this IEnumerable<JnWord> JnWords
	){
		JnWord R = null!;
		foreach(var (i, JWord) in JnWords.Index()){
			if(i == 0){
				R = JWord;
			}else{
				if(!R.IsSameUserWord(JWord)){
					throw new ErrArg("!IsSameUserWord(R, JWord)");
				}
				R.UpdTimeOfSelfContrastToOther(JWord);
				R.Props.AddRange(JWord.Props);
				R.Learns.AddRange(JWord.Learns);
			}
		}//~foreach
		return R;
	}

	public static JnWord SortByCreatedAtAsc(
		this JnWord z
	){
		z.Props.Sort((a,b)=>a.CreatedAt.Value.CompareTo(b.CreatedAt));
		z.Learns.Sort((a,b)=>a.CreatedAt.Value.CompareTo(b.CreatedAt));
		return z;
	}

	public static bool IsSynced(
		this JnWord Other
		,JnWord Existing
	){
		if(!Other.IsSameUserWord(Existing)){
			throw new ErrArg("!IsSameUserWord(z, Other)");
		}
		if(//視潙同一詞 返null
			Other.CreatedAt == Existing.CreatedAt
			&& Other.UpdatedAt == Existing.UpdatedAt
			&& Other.Props.Count == Existing.Props.Count
			&& Other.Learns.Count == Existing.Learns.Count
		){
			return true;
		}
		return false;
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

