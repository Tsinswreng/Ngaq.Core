#define Impl
using Ngaq.Core.Shared.Word.Models.Weight;

namespace Ngaq.Core.Word.Models.Weight;

public partial class OptWeightResult: IOptWeightResult{
	//ICfgWeight.ESortBy ICfgWeight.SortBy{get;set;}
	public ESortBy SortBy{get;set;}
	#if Impl
		= ESortBy.Weight;
	#endif
	public EResultType ResultType{get;set;}
	#if Impl
		= EResultType.ItblIWordWeightResult;
	#endif

}

