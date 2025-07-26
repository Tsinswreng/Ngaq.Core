#define Impl
namespace Ngaq.Core.Word.Models.Weight;

public  partial class CfgWeightResult: ICfgWeightResult{
	//ICfgWeight.ESortBy ICfgWeight.SortBy{get;set;}
	public ESortBy SortBy{get;set;}
	#if Impl
		= ESortBy.Weight;
	#endif
	public EResultType ResultType{get;set;}
	#if Impl
		= EResultType.Enumerable;
	#endif

}

