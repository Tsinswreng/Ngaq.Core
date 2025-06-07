namespace Ngaq.WeightAlgo.Models;

public class WeightCfg{
	// public IDictionary<u64, f64> AddCnt_Bonus = new Dictionary<u64, f64>(){
	// 	[0] = 0x1
	// 	,[1] = 0xff
	// 	,[2] = 0xfff
	// 	,[3] = 0xffff
	// };
	public IList<f64> AddCnt_Bonus = new List<f64>(){
		0x1,0xff,0xfff,0xffff
	};
	public f64 DfltAddBonus = 0xffffff;
	/// <summary>
	/// ʃᶤ削弱 ʹ分母
	/// </summary>
	public f64 DebuffNumerator = 36*ETimeInMs.Day;
	public f64 Base = 20;
	public f64 FinalAddBonusDenominator = ETimeInMs.Day*3000;
}
