namespace Ngaq.Core.Word.WeightAlgo.Models;

public class WeightWordState{
	/// <summary>
	/// 當前ʹ時 㕥計權重
	/// </summary>
	public i64 Now{get;set;} = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	/// <summary>
	/// 權重。初始化作1.1蔿做乘法旹不潙自
	/// </summary>
	public f64 Weight{get;set;} = 1.1;
	/// <summary>
	/// 當前在[Time, Learn][]中之索引
	/// </summary>
	public u64 Pos{get;set;} = 0;
	/// <summary>
	/// 當前已遍歷到ʹ數芝'add'ˉ學習記錄ʹ
	/// </summary>
	public u64 CurCntAdd{get;set;} = 0;
	/// <summary>
	/// 當前已遍歷到ʹ數芝'rmb'ˉ學習記錄ʹ
	/// </summary>
	public u64 CurCntRmb{get;set;} = 0;
	/// <summary>
	/// 當前已遍歷到ʹ數芝'fgt'ˉ學習記錄ʹ
	/// </summary>
	public u64 CurCntFgt{get;set;} = 0;
	/// <summary>
	/// 當前遍歷到ʹ 末個'add'之後ʹ數芝'rmb'ˉ學習記錄ʹ
	/// </summary>
	public u64 CurCntValidRmb{get;set;}=0;

	/// <summary>
	/// 末個'add'ˉ學習記錄之位。 當計于傳入單詞並初始化算法器旹
	/// </summary>
	public u64 PosFinalAdd{get;set;} = 0;

}
