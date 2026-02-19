namespace Ngaq.Core.Shared.Word.Models.Weight;

public enum ESortBy:i64{
	Weight = 1
	,Pos = 2
}

public enum EResultType:i64{
	ItblIWordWeightResult = 1
	,AsyEIWordWeightResult =2
}


public partial interface IOptWeightResult{

	public ESortBy SortBy{get;set;}
	#if Impl
		= ESortBy.Weight;
	#endif
	public EResultType ResultType{get;set;}
	#if Impl
		= EResultType.Enumerable;
	#endif
}
