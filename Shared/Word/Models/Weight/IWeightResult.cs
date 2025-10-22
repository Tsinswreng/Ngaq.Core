using Tsinswreng.CsTools;

namespace Ngaq.Core.Word.Models.Weight;


public partial interface IWeightResult:ITypedObj{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeight();
	#endif
	//IWordWeightResult
	public obj? Results{get;set;}
}
