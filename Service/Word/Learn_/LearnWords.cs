using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Service.Word.Learn_.Models;

namespace Ngaq.Core.Service.Word;

public class LearnStatus{
	public bool Load = false;
	public bool Start = false;
	public bool Save = true;
}

public class StateLearnedWords{
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


}

public class StateLearnWords{
	public IList<IWordForLearn> WordsToLearn { get; set; } = new List<IWordForLearn>();
	public StateLearnedWords StateLearnedWords { get; set; } = new StateLearnedWords();
	public LearnStatus LearnStatus {get;set;} = new ();

}



public class LearnMgr{

	public LearnMgr(){}

	public LearnMgr(
		ISvcWord? SvcWord
	){
		this.SvcWord = SvcWord;
	}

	public ISvcWord? SvcWord{get;set;}

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
	public class EErr:IEnumErr{
		protected static EErr? _Inst = null;
		public static EErr Inst => _Inst??= new EErr();
		public static IAppErr Mk(i64 Code, str Msg){
			return new ErrApp{
				Code = Code, Message = Msg
				,Namespace = nameof(LearnMgr)
			};
		}
		public IAppErr LoadFailed() => Mk(1000, "Load failed");
		public IAppErr SaveFailed() => Mk(2000, "Save failed");

	}

	public StateLearnWords State{get;set;} = new();
	public nil Load(IEnumerable<JoinedWord> JWords){
		State.WordsToLearn.Clear();
		foreach(var JWord in JWords){
			var Word = new WordForLearn(JWord);
			State.WordsToLearn.Add(Word);
		}
		State.LearnStatus.Load = true;
		State.LearnStatus.Start = true;
		return Nil;
	}


	public nil Learn(
		IWordForLearn Word
		,Learn Learn
	){
		if(!State.LearnStatus.Start){
			return Nil;
		}
		State.StateLearnedWords.Set(Learn, Word);
		return Nil;
	}

	public async Task<nil> SaveAsy(){
		try{
			//TODO
		}
		catch (System.Exception e){
			var E = EErr.Inst.SaveFailed();
			E.Errors.Add(e);
			return Err(E);
		}
		return Nil;
	}
}
