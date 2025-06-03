#define Impl
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public interface IWordToLearn
	:IPoWord
	,I_Id
	,I_Weight
	,I_Learn_Records
	,I_StrKey_Props
	,I_LearnRecords
{

}

public class WordForLearn
	:IWordToLearn
{
	protected PoWord PoWord{get;set;}
	protected JoinedWord _JoinedWord{get;set;}
	public WordForLearn(
		JoinedWord JWord
	){
		this._JoinedWord = JWord;
		this.PoWord = JWord.PoWord;
		StrKey_Props.FromPoKvs(_JoinedWord.Props);
		Learn_Records.FromPoLearns(_JoinedWord.Learns);
		LearnRecords = _JoinedWord.Learns
			.Select(x=>x.ToLearnRecord())
			.OrderBy(x=>x.Time)
			.ToList()
		;
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

	public IList<ILearnRecord> LearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif


	public IdWord Id{
		get{return PoWord.Id;}
		set{
			_JoinedWord.Id = (IdWord)value;
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
