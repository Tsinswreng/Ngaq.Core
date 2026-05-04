namespace Ngaq.Core.Shared.Word.WeightAlgo;

using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.WeightAlgo.Models;
using Ngaq.Core.Word.WeightAlgo.Models;
using Tsinswreng.CsTempus;
using Tsinswreng.CsTools;



public partial class CalculatorForOne{
	public DfltWeightCfg Cfg{get;set;} = new();
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

	[Doc(@$"預先算好必要數據")]
	nil _PreCount(){
		_FindFinalAddPos();
		return NIL;
	}

	[Doc(@$"初始化{nameof(WordState.PosFinalAdd)}")]
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

	public async Task<nil> RunAsy(CT Ct){
		//return Task.Run(Run, Ct);
		return Run();
	}

	[Doc("計算當前單詞的權重 並賦值")]
	public nil Run(){
		var Word = State.Word;
		//Word.SavedLearnRecords //TODO 確保此潙以時升序
		//按時間順序遍歷所有事件
		for(var i = 0; i < Word.LearnRecords.Count; i++, State.WordState.Pos++){
			var LearnRecord = Word.LearnRecords[i];
			//根據當前事件 做相應處理
			if(LearnRecord.Learn == ELearn.Add){
				_Add();
			}else if(LearnRecord.Learn == ELearn.Rmb){
				_Rmb();
			}else if(LearnRecord.Learn == ELearn.Fgt){
				_Fgt();
			}
			//如果是處理最後一個事件 再做額外處理
			if(i == Word.LearnRecords.Count-1){
				_HandleFinal();
			}
		}
		return NIL;
	}

	[Doc(@$"處理 添加事件。
	「添加」指一個單詞被加入詞庫。
	一個單詞能被多次加入詞庫。「添加」事件越多代表這個單詞越重要。故「添加」事件會使權重變大
	")]
	nil _Add(){
		WordState.CurCntAdd++;
		WordState.CurCntValidRmb = 0;
		var coefficient0 = Cfg.AddCnt_Bonus.AtOrDefault(WordState.CurCntAdd.AsI32()-1, Cfg.DfltAddBonus);
		var coefficient = coefficient0;
		
		f64? FinalAddBonus;
		if(WordState.Pos == WordState.PosFinalAdd){
			//若當前處理的事件 是 所有「添加」事件中的最後一個
			//則給權重 增益
			FinalAddBonus = _CalcFinalAddBonus();
			coefficient *= FinalAddBonus.Value;
		}
		WordState.Weight *= coefficient;
		//TODO log change of weight

		return NIL;
	}

	[Doc(@$"處理「記得」事件。會使權重變小")]
	nil _Rmb(){
		WordState.CurCntRmb++;
		
		var coefficient0 = _CalcTimeWeightForCur();
		
		f64 debuff;//負加成

		//TOFIX 蠹:finalAddEventPos之前者亦有debuff?
		_ = @$"當 當前事件 在 {nameof(WordState.PosFinalAdd)} 之後
		且 所有事件中的最後一個事件是 「記得」 事件 時、
		算一個負加成 讓 權重變得更小。目標是使 剛背過的單詞 在短時間內 更不容易出現。
		";
		if(//若有debuff
			WordState.Pos >= WordState.PosFinalAdd
			&& _GetFinalLearnRecord().Learn == ELearn.Rmb
		){
			debuff = _CalcDebuff();
			var coefficient = coefficient0 * debuff;
			No0(ref coefficient);
			WordState.Weight /= coefficient; //權重除以係數 使權重更小
		}else{
			No0(ref coefficient0);
			WordState.Weight /= coefficient0;
		}
		//TODO log change
		return NIL;
	}

	[Doc(@$"處理「忘記」事件。會使權重變大")]
	nil _Fgt(){
		WordState.CurCntFgt++;
		var Prev = _GetPrevLearnRecord();//上個學習事件
		f64 coefficient0 = _CalcTimeWeightForCur();
		_ = @$"添加次數越多表示單詞越重要。
		對于更重要的單詞、忘記事件的權重增幅應該更大 相比于 不重要的單詞。
		故用係數乘以 單詞添加次數
		";
		coefficient0 *= WordState.CurCntAdd; // curPos之後之cnt_add不算
		//不讓係數太大 一個單詞可能會被忘記很多次。
		// 「記得」事件與「忘記」事件使用類似的算法、使「忘記」事件的權重增長不要太大
		coefficient0 /= 10;
		_ = @$"如果上個事件剛好是 「添加」 事件 就讓權重更大、讓被加過的單詞更容易先被學一輪";
		if(Prev.Learn == ELearn.Add){
			coefficient0 *= 4;
		}
		WordState.Weight *= coefficient0;
		//TODO log change
		return NIL;
	}

	[Doc(@$"額外處理最後一個學習記錄")]
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

	[Doc(@$"最基礎的 時間權重係數。
	目標: 将时间差映射为权重，且权重随着时间差增大而增大，但增幅逐渐放缓
	#Params([毫秒級時間差])
	主要流程 : 以秒爲單位 取 時間差 的 四次方根。
	f(t) = t^(1/4) 這個函數、隨 t 單調遞增。 符合: 時間差越大, 時間權重越大。
	當 t 越大時, 隨着 t 增大, f(t) 增幅越不明顯 (一階導數遞減, 增长率递减)
	")]
	f64 _CalcTimeWeight(i64 TimeDiffMs){
		f64 R = TimeDiffMs;
		R /= 1000; //轉化成秒。 毫秒級不方便理解
		//R = Math.Pow(R, 1/4); //整數除法 1/4 得0
		R = Math.Pow(R, 1.0/4);
		if(R <= 1){
			R = 1.01;
		}
		return R;
	}

	[Doc(@$"
	當前事件的時間 減去 上個事件的時間 再用時間差 去 {nameof(_CalcTimeWeight)} 算權重。
	")]
	f64 _CalcTimeWeightForCur(){
		var TimeDiffMs = _TimeMsCurDiffPrev();
		return _CalcTimeWeight(TimeDiffMs);
	}


	[Doc(@$"當 當前事件 在 {nameof(WordState.PosFinalAdd)} 之後
	且 所有事件中的最後一個事件是 「記得」 事件 時、
	算一個負加成 讓 權重變得更小。目標是使 剛背過的單詞 在短時間內 更不容易出現。
	")]
	f64 _CalcDebuff(){
		f64 R = 1;
		_ = @$"當前時間 到 當前學習記錄 的 時間差";
		var Diff = _Now() - _GetCurLearnRecord().UnixMs;
		var DebuffNumerator = Cfg.DebuffNumerator;
		//12 小時內學過的詞，降權效果會被極大放大，讓它更不容易再次出現。
		if((u64)Diff < ETimeInMs.Hour * 12){
			DebuffNumerator *= 0xffffffff;
		}
		_ = @$" f(t) = a / (t - b) 然後 取絕對值 
		這是 反比例函數芝、但橫軸往右偏移了 b。
		- 在 t 屬于 (b, 正無窮) 的區間內 t越大、f(t)越小。越難以掩蓋目標單詞的出現
		- 在 t 屬于 (0, b) 的 區間內, t越大、f(t)越大。越容易掩蓋目標單詞的出現 
		在 t 屬于 (0, b) 的 區間內 設計比較奇怪、預期的想法是 仍然是 t越大、f(t)越小、但 下降的幅度更慢、f(t)值 比 (b, 正無窮)的 f(t) 值 遠大
		";
		R = DebuffNumerator/(Diff - ((i64)ETimeInMs.Min*100)); // 冀 岡憶得之詞 于100分鐘內不復出 ??
		R = Math.Abs(R);
		if(R < 1){
			R = 1;
		}
		return R;
	}

	[Doc(@$"當前Unix毫秒時間戳")]
	i64 _Now(){
		return UnixMs.Now();
	}


	[Doc(@$"當 當前處理的事件 是 所有「添加」事件中的最後一個 時
	給單詞權重乘上一個額外增益係數。
	具體規則/目標:
	末次 加事件越近、加成越大。
	#Rtn[額外增益係數、 用于乘到單詞權重上]
	")]
	f64 _CalcFinalAddBonus(){
		f64 R = _NowDiffFinalAddTime();
		No0(ref R);//R要作除數、確保非0
		
		_ = @$"
		t:= _NowDiffFinalAddTime 即 當前時間 減 最末一次添加 所發生的時間。
		函數 f(t) = FinalAddBonusDenominator / t
		這是反比例函數
		隨着當前時間增大、 t 也增大、 f(t)則會變小。符合目標: 末次 加事件越近、加成越大。
		";
		R = Cfg.FinalAddBonusDenominator / R;
		
		_ = @$"再讓返回的加成係數除以一次記得次數。
		目標: 記得ʹ次數越多 加成越少。記得次數多說明已經對這個單詞比較熟悉了、不需要這麼多加成
		+1是蔿使其不潙0";
		R = R / State.WordState.CurCntRmb + 1;
		if(R < 1){//確保不小於1。小於1則 權重與係數的乘除操作 會出意外
			R = 1;
		}
		return R;
	}

/// 末ʹ事件潙加旹 算加成
/// 其日期距今ʹ期 越短 則加成越大、即他ʹ況ˋ同旹、ʃ被加ʹ期更近 之詞ˋ更優先
	f64 _CalcBonusWhenFinalIsAdd(){
		var DiffMs = _Now() - _GetCurLearnRecord().UnixMs;
		var DiffS = DiffMs/1000;
		No0(ref DiffS);
		f64 R = (i64)ETimeInMs.Day*360000 / DiffS;
		if(R < 1){
			R = 1;
		}
		return R;
	}

	[Doc(@$"UnixMs下 當前時間 減 最末一次添加 所發生的時間")]
	i64 _NowDiffFinalAddTime(){
		var FinalAdd = _GetFinalAdd();
		var R = WordState.Now - FinalAdd.UnixMs;
		if(R < 0){
			throw new Exception("final Add time is earlier than now");
		}
		return R;
	}

	[Doc(@$"確保數值不爲0、若爲0則改爲1。
	保證除法運算時不出錯
	")]
	static void No0(ref f64 z){
		if(z == 0){
			z = 1;
		}
	}

	
	static void No0(ref i64 z){
		if(z == 0){
			z = 1;
		}
	}


}
