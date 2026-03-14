namespace Ngaq.Core.Word.WeightAlgo.Models;

public  partial class WeightWordState{
	/// 當前ʹ時 㕥計權重
	public i64 Now{get;set;} = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	/// 權重。初始化作1.1蔿做乘法旹不潙自
	public f64 Weight{get;set;} = 1.1;
	/// 當前在[Time, Learn][]中之索引
	public u64 Pos{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'add'ˉ學習記錄ʹ
	public u64 CurCntAdd{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'rmb'ˉ學習記錄ʹ
	public u64 CurCntRmb{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'fgt'ˉ學習記錄ʹ
	public u64 CurCntFgt{get;set;} = 0;
	/// 當前遍歷到ʹ 末個'add'之後ʹ數芝'rmb'ˉ學習記錄ʹ
	public u64 CurCntValidRmb{get;set;}=0;

	/// 末個'add'ˉ學習記錄之位。 當計于傳入單詞並初始化算法器旹
	public u64 PosFinalAdd{get;set;} = 0;

}
