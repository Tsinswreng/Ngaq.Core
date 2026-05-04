using Tsinswreng.CsTempus;

namespace Ngaq.Core.Shared.Word.WeightAlgo.Models;

public partial class WeightWordState{
	/// 當前ʹ時 㕥計權重
	[Doc(@$"當前Unix毫秒時間戳")]
	public i64 Now{get;set;} = UnixMs.Now();
	/// 權重。初始化作1.1蔿做乘法旹不潙自
	public f64 Weight{get;set;} = 1.1;
	/// 當前在[Time, Learn][]中之索引
	[Doc(@$"按時間順序的學習記錄中 當前在處理第幾個事件(從0開始)")]
	public u64 Pos{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'add'ˉ學習記錄ʹ
	[Doc(@$"當前 已經 遍歷過了 第幾個 「添加」事件。(包含當前正在處理的事件)
	不等於 所有 添加事件 的數量
	")]
	public u64 CurCntAdd{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'rmb'ˉ學習記錄ʹ
	[Doc($"與{nameof(CurCntAdd)}類似")]
	public u64 CurCntRmb{get;set;} = 0;
	/// 當前已遍歷到ʹ數芝'fgt'ˉ學習記錄ʹ
	[Doc($"與{nameof(CurCntAdd)}類似")]
	public u64 CurCntFgt{get;set;} = 0;
	/// 當前遍歷到ʹ 末個'add'之後ʹ數芝'rmb'ˉ學習記錄ʹ
	[Doc(@$"ValidRmb(Valid Remember):
	指 最後一個「添加」事件後的「記得」事件。
	假設按時間順序的事件序列是這樣:
	1. 🤔
	2. 🤔
	3. ❌
	4. ❌
	5. ✅
	6. 🤔
	7. ❌
	8. ✅
	9. ✅
	
	則一共發生了3次「添加」事件(🤔)
	最近一次添加事件是第6個事件(🤔)。
	在第6個事件之後的「✅」事件 纔算ValidRmb
	
	")]
	public u64 CurCntValidRmb{get;set;}=0;

	/// 末個'add'ˉ學習記錄之位。 當計于傳入單詞並初始化算法器旹
	[Doc(@$"
	最後一個「添加」事件 的索引。
	
	假設按時間順序的事件序列是這樣:
	0. 🤔
	1. 🤔
	2. 🤔
	3. ❌
	4. ❌
	5. ✅
	6. 🤔
	7. ❌
	8. ✅
	9. ✅
	
	最後一次「🤔」出現在索引爲6處。此時此字段則爲6
	")]
	public u64 PosFinalAdd{get;set;} = 0;

}
