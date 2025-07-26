namespace Ngaq.Core.Word.Models.Weight;


public  partial interface IWeightResult{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeight();
	#endif
	public object? Results{get;set;}
}
