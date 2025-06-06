namespace Ngaq.Core.Word.Models.Weight;


public interface IWeightResult{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeight();
	#endif
	public object? Results{get;set;}
}
