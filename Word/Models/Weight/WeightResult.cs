#define Impl
namespace Ngaq.Core.Word.Models.Weight;
public  partial class WeightResult: IWeightResult{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeightResult();
	#endif
	public object? Results{get;set;}
}
