#define Impl
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
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
		SavedLearnRecords = _JoinedWord.Learns
			.Select(x=>x.ToLearnRecord())
			.OrderBy(x=>x.UnixMs)
			.ToList()
		;
	}

	public event PropertyChangedEventHandler? PropertyChanged;//受保護之委託 不能在類外調
	public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null){
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}


	public f64 Weight{get;set;} = 0;
	public i64? Index{get;set;}

	public IDictionary<str, IList<IProp>> StrKey_Props{get;set;}
	#if Impl
	= new Dictionary<str, IList<IProp>>();
	#endif

	public IDictionary<Learn, IList<ILearnRecord>> Learn_Records{get;set;}
	#if Impl
	= new Dictionary<Learn, IList<ILearnRecord>>();
	#endif

	public IList<ILearnRecord> SavedLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif

	// public IDictionary<i64, LearnRecord> Time_UnsavedLearnRecords{get;set;}
	// #if Impl
	// = new Dictionary<i64, LearnRecord>();
	// #endif
	public IList<ILearnRecord> UnsavedLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif


	//public i64 LastLearnedTime{get;set;}

	public IdWord Id{
		get{return PoWord.Id;}
		set{
			_JoinedWord.Id = value;
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
	public i64 CreatedAt{
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

}


public static class ExtnIWordForLearn{
	public static i64 LastLearnedTime_(
		this IWordForLearn z
	){
		if(z.SavedLearnRecords.Count > 0){
			return z.SavedLearnRecords[^1].UnixMs;
		}
		return 0;//should not happen
	}

	public static nil SaveUnsavedLearnRecordsEtClear(
		this IWordForLearn z
	){
		z.SavedLearnRecords.AddRange(z.UnsavedLearnRecords);
		z.Learn_Records.AddFromLearnRecords(z.UnsavedLearnRecords);//TODO 把學習記錄專封到一個類中。否則改于外易漏
		z.UnsavedLearnRecords.Clear();
		z.OnPropertyChanged("");//事件“INotifyPropertyChanged.PropertyChanged”只能出现在 += 或 -= 的左边CS0079
		return Nil;
	}
}
