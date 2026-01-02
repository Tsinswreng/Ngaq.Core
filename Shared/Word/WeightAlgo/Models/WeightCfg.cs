using System.Collections;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.WeightAlgo.Models;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Shared.Word.WeightAlgo.Models;

public partial class WeightCfg{
	// public IDictionary<u64, f64> AddCnt_Bonus = new Dictionary<u64, f64>(){
	// 	[0] = 0x1
	// 	,[1] = 0xff
	// 	,[2] = 0xfff
	// 	,[3] = 0xffff
	// };
	public IList<f64> AddCnt_Bonus = new List<f64>(){
		0xff,0xfff,0xffff,0xfffff //對應 舊版ʹaddWeight
	};
	public f64 DfltAddBonus = 0xffffffff;
	/// <summary>
	/// ʃᶤ削弱 ʹ分母
	/// </summary>
	public f64 DebuffNumerator = 36*ETimeInMs.Day;
	public f64 Base = 20;
	public f64 FinalAddBonusDenominator = ETimeInMs.Day*3000;

	public void InitFromKv(IKvNode Kv){
		var z = this;
		var AddCnt_Bonus = Kv[nameof(z.AddCnt_Bonus)];
		if(AddCnt_Bonus is IList L){
			var bonusList = new List<f64>();
			foreach(var ele in L){
				var toAdd = ToF64(ele);
				if(toAdd is not null){
					bonusList.Add(toAdd.Value);
				}
			}
			z.AddCnt_Bonus = bonusList;
		}
		Asn(ref z.DfltAddBonus, Kv[nameof(DfltAddBonus)]);
		Asn(ref z.DebuffNumerator, Kv[nameof(DebuffNumerator)]);
		Asn(ref z.Base, Kv[nameof(Base)]);
		Asn(ref z.FinalAddBonusDenominator, Kv[nameof(FinalAddBonusDenominator)]);
		static f64? ToF64(obj? V){
			if(V is not null){
				if(V is i64 || V is f64){
					return (f64)V;
				}
			}
			return null;
		}
		static void Asn(ref f64 ToBeAssign, obj? V){
			var f = ToF64(V);
			if(f is not null){
				ToBeAssign = f.Value;
			}
		}
	}
}
