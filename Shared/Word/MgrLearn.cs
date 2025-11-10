namespace Ngaq.Core.Shared.Word;

using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Word.Req;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsTools;
using Ngaq.Core.Frontend.User;
using MoonSharp.Interpreter;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

public enum ELearnOpRtn{
		Learn = 0
		,Undo = 1
		,Invalid = 2
	}

public partial class OperationStatus{
	public bool Load = false;
	public bool Start = false;
	public bool Save = true;
}

public partial class MgrLearnedWords{
	public IDictionary<ELearn, IDictionary<IWordForLearn, nil>> Learn_WordSet{get;set;}
	= new Dictionary<ELearn, IDictionary<IWordForLearn, nil>>();

	protected IDictionary<IWordForLearn, nil> GetWordSet(ELearn Learn){
		if(Learn_WordSet.TryGetValue(Learn, out var WordSet)){
			return WordSet;
		}else{
			WordSet = new Dictionary<IWordForLearn, nil>();
			Learn_WordSet.Add(Learn, WordSet);
			return WordSet;
		}
	}

	public nil Set(
		ELearn Learn
		,IWordForLearn Word
	){
		var WordSet = GetWordSet(Learn);
		WordSet[Word] = NIL;
		return NIL;
	}

	public nil DeleteWordFromLearnGroup(
		ELearn Learn
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

public partial class StateLearnWords{
	public IList<IWordForLearn> WordsToLearn { get; set; } = new List<IWordForLearn>();
	public MgrLearnedWords MgrLearnedWords { get; set; } = new MgrLearnedWords();
	public OperationStatus OperationStatus {get;set;} = new ();

}


public partial class LearnEventArgs :EventArgs{
	public IWordForLearn? Word{get;set;}
	public ELearn Learn{get;set;}
	public bool IsUndo{get;set;} = false;
}

/// <summary>
/// 只會在前端運行
/// </summary>
public partial class MgrLearn{

	//public MgrLearn(){}


	public ISvcWord SvcWord{get;set;}//TODO 接口隔離
	//IUserCtx UserCtx;
	IFrontendUserCtxMgr UserCtxMgr;
	public IWeightCalctr WeightCalctr{get;set;}
	ILogger? Logger;
	public MgrLearn(
		ISvcWord SvcWord
		,IWeightCalctr WeightCalctr
		,IFrontendUserCtxMgr UserCtxMgr
		,ILogger? Logger
	){
		this.WeightCalctr = WeightCalctr;
		this.SvcWord = SvcWord;
		this.UserCtxMgr = UserCtxMgr;
		this.Logger = Logger;
	}

	public event EventHandler<LearnEventArgs>? OnLearnOrUndo;



	public partial class EvtArgOnErr:EventArgs{
		public object? Err{get;set;}
	}

	public event EventHandler<EvtArgOnErr>? OnErr;
	public object? LastErr{get;set;}
	public nil Err(object? Err){
		LastErr = Err;
		OnErr?.Invoke(this, new EvtArgOnErr{Err=Err});
		return NIL;
	}

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

	public async Task<nil> LoadEtCalcWeightAsy(
		IAsyncEnumerable<IJnWord> JnWords
		,CT Ct
	){
		var z = this;
		var WordsForLearn = JnWords.Select(x=>new WordForLearn(x));
		var sw = Stopwatch.StartNew();
		var WeightResult = await WeightCalctr.CalcAsy(WordsForLearn, Ct);
		sw.Stop();
		z.Logger?.LogInformation($"WeightCalctr.CalcAsy: {sw.ElapsedMilliseconds}ms");


		State.WordsToLearn.Clear();
		await foreach(var Word in WordsForLearn){
			State.WordsToLearn.Add(Word);
		}
		State.OperationStatus.Load = true;
		await HandleWeightResult(WeightResult, Ct);
		return NIL;
	}

	/// <summary>
	/// 取諸詞
	/// </summary>
	/// <param name="JWords"></param>
	/// <returns></returns>
	[Obsolete("用LoadEtCalcWeightAsy更快")]
	public nil Load(IEnumerable<IJnWord> JWords){
		State.WordsToLearn.Clear();
		foreach(var (i,JWord) in JWords.Index()){
			var Word = new WordForLearn(JWord);
			State.WordsToLearn.Add(Word);
		}
		State.OperationStatus.Load = true;
		return NIL;
	}

	public async Task<nil> CalcWeightAsy(CT Ct){
		if(!State.OperationStatus.Load){
			return NIL;
		}
		var WeightResult = await WeightCalctr.CalcAsy(State.WordsToLearn, Ct);
		await HandleWeightResult(WeightResult, Ct);

		return NIL;
	}

	protected async Task<nil> HandleWeightResult(IWeightResult WeightResult, CT Ct){
		IDictionary<IdWord, IWordWeightResult> Id_Result;
		if(WeightResult.Cfg.ResultType == EResultType.Enumerable_IWordWeightResult){
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

	public async Task<nil> CalcWeightEtStartAsy(CT Ct){
		if(!State.OperationStatus.Load){
			return NIL;
		}
		await CalcWeightAsy(Ct);
		await StartAsy(Ct);
		return NIL;
	}

	public async Task<nil> StartAsy(CT Ct){
		if(!State.OperationStatus.Load){
			return NIL;
		}
		State.OperationStatus.Start = true;
		return NIL;
	}



/// <summary>
///
/// </summary>
/// <param name="Word"></param>
/// <param name="Learn"></param>
/// <returns>見ELearnOpRtn</returns>
	ELearnOpRtn _Learn(
		IWordForLearn Word
		,ELearn Learn
	){
		if(!State.OperationStatus.Start){
			return ELearnOpRtn.Invalid;
		}
		var LearnRecord = new LearnRecord(Learn);
		var R = Word.AddLearnRecordIfEmpty(LearnRecord);
		State.OperationStatus.Save = false;
		if(R == 0){
			State.MgrLearnedWords.Set(Learn, Word);
			OnLearnOrUndo?.Invoke(this, new LearnEventArgs{Word=Word, Learn=Learn, IsUndo=false});
			return ELearnOpRtn.Learn;
		}
		return ELearnOpRtn.Undo;
	}

	ELearnOpRtn _Undo(
		IWordForLearn Word
	){
		if(!State.OperationStatus.Start){
			return ELearnOpRtn.Invalid;
		}
		var Last = Word.RmLastUnsavedLearnRecord();
		if(Last != null){
			State.MgrLearnedWords.DeleteWordFromLearnGroup(Last.Learn, Word);
			OnLearnOrUndo?.Invoke(this, new LearnEventArgs{Word=Word, Learn=Last.Learn, IsUndo=true});
			return ELearnOpRtn.Undo;
		}
		return ELearnOpRtn.Invalid;
	}


	public ELearnOpRtn LearnOrUndo(
		IWordForLearn Word
		,ELearn Learn
	){
		if(!State.OperationStatus.Start){
			return ELearnOpRtn.Invalid;
		}
		if(_Learn(Word, Learn) != ELearnOpRtn.Learn){
			return _Undo(Word);
		}
		return ELearnOpRtn.Learn;
	}

	public async Task<nil> SaveAsy(CT Ct){
		try{
			var UserCtx = UserCtxMgr.GetUserCtx();
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
				UserCtx
				,WordId_LearnRecordss
				,Ct
			);
			HandleLearnRecordsOnSave();
			ResetLearnedState();
			State.OperationStatus.Save = true;
		}
		catch (Exception e){
			var E = ItemsErr.Word.SaveWordListFailed.ToErr();
			E.AddErr(e);
			Err(E);
		}
		return NIL;
	}

	public nil Reset(){
		//ResetLearnedState();
		State = new();
		return NIL;
	}

	void Filter(){
		var sc = new Script();
	}
}
