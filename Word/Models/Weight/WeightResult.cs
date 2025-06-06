#define Impl
namespace Ngaq.Core.Word.Models.Weight;
public class WeightResult: IWeightResult{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeightResult();
	#endif
	public object? Results{get;set;}
}
