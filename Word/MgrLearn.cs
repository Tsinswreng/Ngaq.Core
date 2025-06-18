using System.Collections;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.UserCtx;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Service.Word;

using Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsCore.Tools;

namespace Ngaq.Core.Word;

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
		WordSet[Word] = NIL;
		return NIL;
	}

	public nil DeleteWordFromLearnGroup(
		Learn Learn
		,IWordForLearn Word
	){
		var WordSet = GetWordSet(Learn);
		if(WordSet.ContainsKey(Word)){
			WordSet.Remove(Word);
		}
		return NIL;
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


public class LearnEventArgs :EventArgs{
	public IWordForLearn? Word{get;set;}
	public Learn Learn{get;set;}
	public bool IsUndo{get;set;} = false;
}

public class MgrLearn{

	//public MgrLearn(){}

	public MgrLearn(
		ISvcWord SvcWord
		,IUserCtxMgr UserCtxMgr
		,IWeightCalctr WeightCalctr
	){
		this.WeightCalctr = WeightCalctr;
		this.UserCtxMgr = UserCtxMgr;
		this.SvcWord = SvcWord;
	}

	public ISvcWord SvcWord{get;set;}//TODO 接口隔離
	public IUserCtxMgr UserCtxMgr{get;set;}
	public IWeightCalctr WeightCalctr{get;set;}

	public event EventHandler<LearnEventArgs>? OnLearnOrUndo;


	public enum ELearnOpRtn:i64{
		Learn = 0
		,Undo = 1
		,Invalid = 2
	}

	public class EvtArgOnErr:EventArgs{
		public object? Err{get;set;}
	}
	public event EventHandler<EvtArgOnErr>? OnErr;
	public object? LastErr{get;set;}
	public nil Err(object? Err){
		LastErr = Err;
		OnErr?.Invoke(this, new EvtArgOnErr{Err=Err});
		return NIL;
	}
	public class EErr_:EnumErr{
		protected static EErr_? _Inst = null;
		public static EErr_ Inst => _Inst??= new EErr_();

		public IAppErr LoadFailed() => Mk(nameof(LoadFailed));
		public IAppErr SaveFailed() => Mk(nameof(SaveFailed));
	}
	public EErr_ EErr{get;set;} = EErr_.Inst;
	public StateLearnWords State{get;set;} = new();

	nil ResetLearnedState(){
		State.MgrLearnedWords = new();
		return NIL;
	}

	nil HandleLearnRecordsOnSave(){
		foreach(var Word in State.MgrLearnedWords.GetLearnedWords()){
			Word.HandleLearnRecordsOnSave();
		}
		return NIL;
	}



	/// <summary>
	/// 取諸詞
	/// </summary>
	/// <param name="JWords"></param>
	/// <returns></returns>
	public nil Load(IEnumerable<JnWord> JWords){
		State.WordsToLearn.Clear();
		foreach(var JWord in JWords){
			var Word = new WordForLearn(JWord);
			State.WordsToLearn.Add(Word);
		}
		State.OperationStatus.Load = true;
		//State.OperationStatus.Start = true;
		return NIL;
	}

	public async Task<nil> CalcWeightAsy(CT Ct){
		if(!State.OperationStatus.Load){
			return NIL;
		}
		var WeightResult = await WeightCalctr.CalcAsy(State.WordsToLearn, Ct);

		IDictionary<IdWord, IWordWeightResult> Id_Result;
		if(WeightResult.Cfg.ResultType == EResultType.Enumerable){
			var Result = (IEnumerable<IWordWeightResult>)WeightResult.Results!;
			Id_Result = Result.ToDictionary(
				x=>IdWord.FromLow64Base(x.StrId)
				,x=>x
			);
		}else{
			var Result = (IAsyncEnumerable<IWordWeightResult>)WeightResult.Results!;
			Id_Result = await Result.ToDictionaryAsync(
				x=>IdWord.FromLow64Base(x.StrId)
				,x=>x
				,Ct
			);
		}

		foreach(var Word in State.WordsToLearn){
			if(Id_Result.TryGetValue(Word.Id, out var Result)){
				Word.Weight = Result.Weight;
				Word.Index  = Result.Index;
			}
		}
		if(WeightResult.Cfg.SortBy == ESortBy.Weight){
			State.WordsToLearn.Sort((b,a)=>(a.Weight??0).CompareTo(b.Weight));
		}else{
			State.WordsToLearn.Sort((a,b)=>(a.Index??0).CompareTo(b.Index));
		}
		u64 i = 0;
		foreach(var Word in State.WordsToLearn){
			Word.Index = i++;
		}
		return NIL;
	}

	public async Task<nil> StartAsy(CT Ct){
		if(!State.OperationStatus.Load){
			return NIL;
		}
		await CalcWeightAsy(Ct);
		State.OperationStatus.Start = true;
		return NIL;
	}



/// <summary>
///
/// </summary>
/// <param name="Word"></param>
/// <param name="Learn"></param>
/// <returns>見ELearnOpRtn</returns>
	i64 _Learn(
		IWordForLearn Word
		,Learn Learn
	){
		if(!State.OperationStatus.Start){
			return (i64)ELearnOpRtn.Invalid;
		}
		State.MgrLearnedWords.Set(Learn, Word);
		var LearnRecord = new LearnRecord(Learn);
		State.OperationStatus.Save = false;
		OnLearnOrUndo?.Invoke(this, new LearnEventArgs{Word=Word, Learn=Learn, IsUndo=false});
		return Word.AddLearnRecordIfEmpty(LearnRecord);
	}

	i64 _Undo(
		IWordForLearn Word
	){
		if(!State.OperationStatus.Start){
			return (i64)ELearnOpRtn.Invalid;
		}
		var Last = Word.RmLastUnsavedLearnRecord();
		if(Last != null){
			State.MgrLearnedWords.DeleteWordFromLearnGroup(Last.Learn, Word);
			OnLearnOrUndo?.Invoke(this, new LearnEventArgs{Word=Word, Learn=Last.Learn, IsUndo=true});
			return (i64)ELearnOpRtn.Undo;
		}
		return (i64)ELearnOpRtn.Invalid;
	}


	public i64 LearnOrUndo(
		IWordForLearn Word
		,Learn Learn
	){
		if(!State.OperationStatus.Start){
			return (i64)ELearnOpRtn.Invalid;
		}
		if(_Learn(Word, Learn) != (i64)ELearnOpRtn.Learn){
			return _Undo(Word);
		}
		return (i64)ELearnOpRtn.Learn;
	}

	public async Task<nil> SaveAsy(CT Ct){
		try{
			if(!State.OperationStatus.Start){
				return NIL;
			}
			var LearnedWord = State.MgrLearnedWords.GetLearnedWords();
			var WordId_LearnRecordss = LearnedWord.Select(x=>{
				var R = new WordId_LearnRecords();
				R.WordId = x.Id;
				R.LearnRecords = x.UnsavedLearnRecords;
				return R;
			});
			await SvcWord.AddWordId_LearnRecordss(
				UserCtxMgr.GetUserCtx()
				,WordId_LearnRecordss
				,Ct
			);
			HandleLearnRecordsOnSave();
			ResetLearnedState();
			State.OperationStatus.Save = true;
		}
		catch (Exception e){
			var E = EErr.SaveFailed();
			E.Errors.Add(e);
			return Err(E);
		}
		return NIL;
	}

	public nil Reset(){
		ResetLearnedState();
		return NIL;
	}
}
