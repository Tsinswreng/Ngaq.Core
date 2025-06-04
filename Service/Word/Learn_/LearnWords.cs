using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.UserCtx;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Service.Word.Learn_.Models;
using Tsinswreng.CsCore.Tools;

namespace Ngaq.Core.Service.Word;

public class OperationStatus{
	public bool Load = false;
	public bool Start = false;
	public bool Save = true;
}

public class MgrLearnedWords{
	public IDictionary<Learn, IDictionary<IWordForLearn, nil>> Learn_WordSet{get;set;}
	= new Dictionary<Learn, IDictionary<IWordForLearn, nil>>();

	protected IDictionary<IWordForLearn, nil> GetWordSet(Learn Learn){
		if(Learn_WordSet.TryGetValue(Learn, out var WordSet)){
			return WordSet;
		}else{
			WordSet = new Dictionary<IWordForLearn, nil>();
			Learn_WordSet.Add(Learn, WordSet);
			return WordSet;
		}
	}

	public nil Set(
		Learn Learn
		,IWordForLearn Word
	){
		var WordSet = GetWordSet(Learn);
		WordSet[Word] = Nil;
		return Nil;
	}

	public nil Delete(
		Learn Learn
		,IWordForLearn Word
	){
		var WordSet = GetWordSet(Learn);
		if(WordSet.ContainsKey(Word)){
			WordSet.Remove(Word);
		}
		return Nil;
	}

	public IEnumerable<IWordForLearn> GetLearnedWords(){
		foreach( var(Learn,WordSet) in Learn_WordSet){
			foreach( var(Word, _) in WordSet ){
				yield return Word;
			}
		}
	}


}

public class StateLearnWords{
	public IList<IWordForLearn> WordsToLearn { get; set; } = new List<IWordForLearn>();
	public MgrLearnedWords MgrLearnedWords { get; set; } = new MgrLearnedWords();
	public OperationStatus OperationStatus {get;set;} = new ();

}



public class LearnMgr{

	public LearnMgr(){}

	public LearnMgr(
		ISvcWord SvcWord
		,IUserCtxMgr UserCtxMgr
	){
		this.SvcWord = SvcWord;
		this.UserCtxMgr = UserCtxMgr;
	}

	public ISvcWord SvcWord{get;set;}//TODO 接口隔離
	public IUserCtxMgr UserCtxMgr{get;set;}

	public class EvtArgOnErr:EventArgs{
		public object? Err{get;set;}
	}
	public event EventHandler<EvtArgOnErr>? OnErr;
	public object? LastErr{get;set;}
	public nil Err(object? Err){
		LastErr = Err;
		OnErr?.Invoke(this, new EvtArgOnErr{Err=Err});
		return Nil;
	}
	public class EErr_:EnumErr{
		protected static EErr_? _Inst = null;
		public static EErr_ Inst => _Inst??= new EErr_();

		public IAppErr LoadFailed() => Mk(nameof(LoadFailed));
		public IAppErr SaveFailed() => Mk(nameof(SaveFailed));
	}
	public EErr_ EErr{get;set;} = EErr_.Inst;


	public StateLearnWords State{get;set;} = new();
	public nil Load(IEnumerable<JnWord> JWords){
		State.WordsToLearn.Clear();
		foreach(var JWord in JWords){
			var Word = new WordForLearn(JWord);
			State.WordsToLearn.Add(Word);
		}
		State.OperationStatus.Load = true;
		State.OperationStatus.Start = true;
		return Nil;
	}


	public nil Learn(
		IWordForLearn Word
		,Learn Learn
	){
		if(!State.OperationStatus.Start){
			return Nil;
		}
		State.MgrLearnedWords.Set(Learn, Word);
		var LearnRecord = new LearnRecord(Learn);
		Word.Time_UnsavedLearnRecords.Add(LearnRecord.UnixMs, LearnRecord);
		State.OperationStatus.Save = false;
		return Nil;
	}

	public async Task<nil> SaveAsy(CT Ct){
		try{
			if(!State.OperationStatus.Start){
				return Nil;
			}
			var LearnedWord = State.MgrLearnedWords.GetLearnedWords();
			var WordId_LearnRecordss = LearnedWord.Select(x=>{
				var R = new WordId_LearnRecords();
				R.WordId = x.Id;
				R.LearnRecords = x.Time_UnsavedLearnRecords.Values;
				return R;
			});
			await SvcWord.AddWordId_LearnRecordss(
				UserCtxMgr.GetUserCtx()
				,WordId_LearnRecordss
				,Ct
			);
			State.MgrLearnedWords = new ();
			State.OperationStatus.Save = true;
		}
		catch (System.Exception e){
			var E = EErr.SaveFailed();
			E.Errors.Add(e);
			return Err(E);
		}
		return Nil;
	}
}
