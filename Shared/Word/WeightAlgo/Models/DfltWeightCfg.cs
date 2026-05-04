using System.Collections;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.WeightAlgo.Models;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Shared.Word.WeightAlgo.Models;

public partial class DfltWeightCfg:IAppSerializable{
	public static str ForName => DfltWeightCalculator.Name;
	public static str Name => "Tswg-EventFlowV1";
	// public IDictionary<u64, f64> AddCnt_Bonus = new Dictionary<u64, f64>(){
	// 	[0] = 0x1
	// 	,[1] = 0xff
	// 	,[2] = 0xfff
	// 	,[3] = 0xffff
	// };
	[Doc(@$"處理「添加」事件時給權重乘的系數。
	- 處理索引爲0的添加事件(第1次添加)時 就給權重乘上 {nameof(AddCnt_Bonus)}[0]
	- 處理索引爲1的添加事件(第2次添加)時 就給權重乘上 {nameof(AddCnt_Bonus)}[1]
	依此類推。
	
	單詞的添加次數 在整個權重算法中是最優先考慮的。
	因 添加次數越多 則說明單詞出現次數越多、該單詞越重要、故乘上的系數越大。
	若「忘記」事件數量多 但「添加」事件不多、只能說明此單詞不熟、但無法說明 此單詞出現頻率高/重要。
	故優先考慮添加次數、按添加次數劃級。
	
	「添加」與「忘記」事件會使單詞的權重增加、「記得」事件會使單詞的權重減少。
	「添加」事件 對 單詞權重的增幅 遠大於 「忘記」事件。
	")]
	public IList<f64> AddCnt_Bonus{get;set;} = new List<f64>(){
		0xff,0xfff,0xffff,0xfffff //對應 舊版ʹaddWeight
	};
	public f64 DfltAddBonus{get;set;} = 0xffffffff;
	
	/// ʃᶤ削弱 ʹ分母
	
	public f64 DebuffNumerator{get;set;} = 36*ETimeInMs.Day;
	public f64 Base{get;set;} = 20;
	public f64 FinalAddBonusDenominator{get;set;} = ETimeInMs.Day*3000;

	public static DfltWeightCfg FromDict(IDictionary<str, obj?> Dict){
		var json = ToolJson.DictToJson(Dict);
		var r = JSON.Parse<DfltWeightCfg>(json);
		return r!;
	}
}
