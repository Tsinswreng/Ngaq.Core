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
