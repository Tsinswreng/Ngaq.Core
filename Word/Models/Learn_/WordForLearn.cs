#define Impl
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;
using Tsinswreng.CsCore.IF;
using Tsinswreng.CsCore.Tools;

namespace Ngaq.Core.Word.Models.Learn_;


public class WordForLearn
	:IWordForLearn
{
	protected PoWord PoWord{get;set;}
	protected JnWord _JoinedWord{get;set;}
	public WordForLearn(
		JnWord JWord
	){
		_JoinedWord = JWord;
		PoWord = JWord.PoWord;
		StrKey_Props.FromPoKvs(_JoinedWord.Props);
		Learn_Records.AddFromPoLearns(_JoinedWord.Learns);
		LearnRecords = _JoinedWord.Learns
			.Select(x=>x.ToLearnRecord())
			.OrderBy(x=>x.UnixMs)
			.ToList()
		;
	}

	public event PropertyChangedEventHandler? PropertyChanged;//受保護之委託 不能在類外調
	public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null){
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	[Impl(typeof(I_Weight))]
	public f64? Weight{get;set;}
	[Impl(typeof(I_Index))]
	public u64? Index{get;set;}

	[Impl(typeof(I_StrKey_Props))]
	public IDictionary<str, IList<IProp>> StrKey_Props{get;set;}
	#if Impl
	= new Dictionary<str, IList<IProp>>();
	#endif

	[Impl(typeof(I_Learn_Records))]
	public IDictionary<Learn, IList<ILearnRecord>> Learn_Records{get;set;}
	#if Impl
	= new Dictionary<Learn, IList<ILearnRecord>>();
	#endif

	[Impl(typeof(I_LearnRecords))]
	public IList<ILearnRecord> LearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif

	// public IDictionary<i64, LearnRecord> Time_UnsavedLearnRecords{get;set;}
	// #if Impl
	// = new Dictionary<i64, LearnRecord>();
	// #endif

	[Impl(typeof(I_UnsavedLearnRecords))]
	public IList<ILearnRecord> UnsavedLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif

	[Impl(typeof(I_PrevTurnLearnRecords))]
	public IList<ILearnRecord> PrevTurnLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif


	//public i64 LastLearnedTime{get;set;}

	[Impl(typeof(I_Id))]
	public IdWord Id{
		get{return PoWord.Id;}
		set{
			_JoinedWord.Id = value;
		}
	}

	[Impl(typeof(IPoWord))]
	public IdUser Owner{
		get{return PoWord.Owner;}
		set{PoWord.Owner = value;}
	}

[Impl(typeof(IPoWord))]
	public str Lang{
		get{return PoWord.Lang;}
		set{PoWord.Lang = value;}
	}

[Impl(typeof(IPoWord))]
	public str Head{
		get{return PoWord.Head;}
		set{PoWord.Head = value;}
	}


	#region IPoBase
[Impl(typeof(IPoBase))]
	public Tempus DbCreatedAt{
		get{return PoWord.DbCreatedAt;}
		set{PoWord.DbCreatedAt = value;}
	}

[Impl(typeof(IPoBase))]
	public Tempus CreatedAt{
		get{return PoWord.CreatedAt;}
		set{PoWord.CreatedAt = value;}
	}

[Impl(typeof(IPoBase))]
	public Tempus? DbUpdatedAt{
		get{return PoWord.DbUpdatedAt;}
		set{PoWord.DbUpdatedAt = value;}
	}

	/// <summary>
	/// 當關聯ʹ他表 更新旹、亦當更新此字段
	/// </summary>
[Impl(typeof(IPoBase))]
	public Tempus? UpdatedAt{
		get{return PoWord.UpdatedAt;}
		set{PoWord.UpdatedAt = value;}
	}
[Impl(typeof(IPoBase))]
	public IdUser? CreatedBy{
		get{return PoWord.CreatedBy;}
		set{PoWord.CreatedBy = value;}
	}
[Impl(typeof(IPoBase))]
	public IdUser? LastUpdatedBy{
		get{return PoWord.LastUpdatedBy;}
		set{PoWord.LastUpdatedBy = value;}
	}
[Impl(typeof(IPoBase))]
	public PoStatus Status{
		get{return PoWord.Status;}
		set{PoWord.Status = value;}
	}


	#endregion IPoBase
[Impl(typeof(I_ShallowCloneSelf))]
	public object ShallowCloneSelf(){
		return MemberwiseClone();
	}

}


public static class ExtnIWordForLearn{
	public static i64 LastLearnedTime_(
		this IWordForLearn z
	){
		if(z.LearnRecords.Count > 0){
			return z.LearnRecords[^1].UnixMs;
		}
		return 0;//should not happen
	}

	/// <summary>
	/// 保存後 把新ʹ學習記錄 添入LearnRecords列表與Learn_Records字典
	/// 把新學習記錄予上輪ʹ學習記錄、緟設新學習記錄
	/// </summary>
	/// <param name="z"></param>
	/// <returns></returns>
	public static nil HandleLearnRecordsOnSave(
		this IWordForLearn z
	){
		z.LearnRecords.AddRange(z.UnsavedLearnRecords);
		z.Learn_Records.AddFromLearnRecords(z.UnsavedLearnRecords);//TODO 把學習記錄專封到一個類中。否則改于外易漏
		z.PrevTurnLearnRecords = z.UnsavedLearnRecords;
		z.UnsavedLearnRecords = new List<ILearnRecord>();
		z.OnPropertyChanged("");//事件“INotifyPropertyChanged.PropertyChanged”只能出现在 += 或 -= 的左边CS0079
		return NIL;
	}
}
