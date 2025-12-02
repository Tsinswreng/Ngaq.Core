using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Word.WeightAlgo.Models;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Word.WeightAlgo;

public partial class CalculatorForOne{
	public WeightCfg Cfg{get;set;} = new();
	public partial class State_{
		public IWeightWord Word{get;set;} = null!;
		public WeightWordState WordState{get;set;} = new();
	}
	public State_ State{get;set;} = new();
	public IWeightWord Word{
		get{return State.Word;}
	}
	public WeightWordState WordState{
		get{return State.WordState;}
	}
	public nil Init(IWeightWord Word){
		State = new();
		State.Word = Word;
		_PreCount();
		return NIL;
	}

	public str Log(str s){
		return s;
	}

	nil _PreCount(){
		_FindFinalAddPos();
		return NIL;
	}

	nil _FindFinalAddPos(){
		for(var i = Word.LearnRecords.Count-1; i>=0; i--){
			var LearnRecord = Word.LearnRecords[i];
			if(LearnRecord.Learn == ELearn.Add){
				WordState.PosFinalAdd = (u64)i;
				break;
			}
		}
		return NIL;
	}

	public Task<nil> RunAsy(CT Ct){
		return Task.Run(Run, Ct);
	}

	public nil Run(){
		var Word = State.Word;
		//Word.SavedLearnRecords //TODO 確保此潙以時升序
		var CntLearn = 0;//temp debug
		for(var i = 0; i < Word.LearnRecords.Count; i++, State.WordState.Pos++){
			var LearnRecord = Word.LearnRecords[i];
			if(LearnRecord.Learn == ELearn.Add){
				CntLearn++;
				_Add();
			}else if(LearnRecord.Learn == ELearn.Rmb){
				_Rmb();
			}else if(LearnRecord.Learn == ELearn.Fgt){
				_Fgt();
			}
			if(i == Word.LearnRecords.Count-1){
				_HandleFinal();
			}
		}
		return NIL;
	}

	nil _Add(){
		WordState.CurCntAdd++;
		var LearnRecord = Word.LearnRecords[WordState.Pos.AsI32()];
		WordState.CurCntValidRmb = 0;
		var weight0 = Cfg.AddCnt_Bonus.AtOrDefault(WordState.CurCntAdd.AsI32()-1, Cfg.DfltAddBonus);
		var weight = weight0;
		f64? FinalAddBonus = null;
		if(WordState.Pos == WordState.PosFinalAdd){
			FinalAddBonus = _CalcFinalAddBonus();
			weight *= FinalAddBonus.Value;
		}
		WordState.Weight *= weight;
		//TODO log change of weight

		return NIL;
	}

	nil _Rmb(){
		WordState.CurCntRmb++;
		var LearnRecord = _GetCurLearnRecord();
		var weight0 = _CalcTimeWeightForCur();
		f64 debuff;

		//TOFIX 蠹:finalAddEventPos之前者亦有debuff
		if(//若有debuff
			WordState.Pos >= WordState.PosFinalAdd
			&& _GetFinalLearnRecord().Learn == ELearn.Rmb
		){
			debuff = _CalcDebuff();
			var weight = weight0 * debuff;
			WordState.Weight /= weight;
		}else{
			WordState.Weight /= weight0;
		}
		//TODO log change
		return NIL;
	}

	nil _Fgt(){
		WordState.CurCntFgt++;
		var Prev = _GetPrevLearnRecord();
		f64 weight0 = _CalcTimeWeightForCur();
		weight0 *= WordState.CurCntAdd; // curPos之後之cnt_add不算
		weight0 /= 10;
		if(Prev.Learn == ELearn.Add){
			weight0 *= 4;
		}
		WordState.Weight *= weight0;
		//TODO log change
		return NIL;
	}

	nil _HandleFinal(){
		var Cur = _GetCurLearnRecord();
		if(Cur.Learn == ELearn.Add){
			var Bonus = _CalcBonusWhenFinalIsAdd();
			if(Bonus < 1.1){
				Bonus = 1.1;
			}
			WordState.Weight *= Bonus;
			//TODO Log
		}//~
		//加ʹ次ˋ大於三之詞 若逾幾日未學習 則增權重
		else if(Cur.Learn == ELearn.Rmb){ //重要單詞
			if(WordState.CurCntAdd >= 3){
				i64 Diff = _Now() - Cur.UnixMs;
				if(Diff > (i64)ETimeInMs.Day*30){
					var Days = Diff/(i64)ETimeInMs.Day;
					WordState.Weight *= Days * 0xfff;
					//TODO Log
				}
			}
		}
		else if( Cur.Learn == ELearn.Fgt){
			var Bonus = _CalcBonusWhenFinalIsAdd(); //借用
			if(Bonus < 1.1){Bonus = 1.1;}
			Bonus *= (WordState.CurCntAdd+1)*2;
			WordState.Weight *= Bonus;
			//TODO log
		}
		return NIL;
	}



	ILearnRecord _GetCurLearnRecord(){
		return Word.LearnRecords[(i32)WordState.Pos];
	}

	ILearnRecord _GetPrevLearnRecord(){
		var R= Word.LearnRecords!.AtOrDefault((i32)WordState.Pos-1, null);
		if(R == null){
			throw new Exception("prev Learn Record not found"); //首個事件必潙add
		}
		return R;
	}

	ILearnRecord _GetFinalLearnRecord(){
		if(Word.LearnRecords.Count == 0){
			throw new Exception("no Learn Record found"); // 首個事件必潙add
		}
		return Word.LearnRecords[^1];
	}

	ILearnRecord _GetFinalAdd(){
		var R = Word.LearnRecords!.AtOrDefault((i32)WordState.PosFinalAdd, null);
		if(R == null){
			throw new Exception("final Add Learn Record not found");// 首個事件必潙add
		}
		return R;
	}

	i64 _TimeMsCurDiffPrev(){
		var Cur = _GetCurLearnRecord();
		var Prev = _GetPrevLearnRecord();
		var R = Cur.UnixMs - Prev.UnixMs;
		if(R < 0){
			throw new Exception("time is earlier than prev");
		}
		return R;
	}

	f64 _CalcTimeWeight(i64 TimeDiffMs){
		f64 R = TimeDiffMs;
		R /= 1000; //sec
		//R = Math.Pow(R, 1/4); //整數除法 1/4 得0
		R = Math.Pow(R, 1.0/4);
		if(R <= 1){
			R = 1.01;
		}
		return R;
	}

	f64 _CalcTimeWeightForCur(){
		var TimeDiffMs = _TimeMsCurDiffPrev();
		return _CalcTimeWeight(TimeDiffMs);
	}

/// <summary>
/// 含FinalAddBonus
/// </summary>
/// <returns></returns>
	f64 _CalcDebuff(){
		f64 R = 1;
		var Diff = _Now() - _GetCurLearnRecord().UnixMs;
		var DebuffNumerator = Cfg.DebuffNumerator;
		if((u64)Diff < ETimeInMs.Hour * 12){
			DebuffNumerator *= 0xffff;
		}
		R = DebuffNumerator/(Diff * ((i64)ETimeInMs.Min*100)); // 冀 岡憶得之詞 于100分鐘內不復出
		R = Math.Abs(R);
		if(R < 1){
			R = 1;
		}
		return R;
	}

	i64 _Now(){
		return DateTimeOffset.Now.ToUnixTimeMilliseconds();
	}





/// <summary>
/// 末次 加事件越近、加成越大。
/// 非 唯末事件潙加旹纔起效
/// </summary>
/// <returns></returns>
	f64 _CalcFinalAddBonus(){
		var NowDiffFinalAddTime = _NowDiffFinalAddTime();
		f64 R = NowDiffFinalAddTime;
		R = Cfg.FinalAddBonusDenominator / R;
		//var LearnedTimes = Word.LearnRecords.Count;
		var Rmb = State.WordState.CurCntRmb+1;//使其不潙0
		R = R / Rmb; //記得ʹ次數越多 加成越少
		if(R < 1){
			R = 1;
		}
		return R;
	}

/// <summary>
/// 末ʹ事件潙加旹 算加成
/// 其日期距今ʹ期 越短 則加成越大、即他ʹ況ˋ同旹、ʃ被加ʹ期更近 之詞ˋ更優先
/// </summary>
/// <returns></returns>
	f64 _CalcBonusWhenFinalIsAdd(){
		var DiffMs = _Now() - _GetCurLearnRecord().UnixMs;
		var DiffS = DiffMs/1000;
		f64 R = (i64)ETimeInMs.Day*360000 / DiffS; //TODO 置斯常數于參數配置?
		if(R < 1){
			R = 1;
		}
		return R;
	}

	i64 _NowDiffFinalAddTime(){
		var FinalAdd = _GetFinalAdd();
		var R = WordState.Now - FinalAdd.UnixMs;
		if(R < 0){
			throw new Exception("final Add time is earlier than now");
		}
		return R;
	}


}
