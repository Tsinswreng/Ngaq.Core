namespace Ngaq.Core.Word.Models.Weight;

public enum ESortBy:i64{
	Weight = 1
	,Pos = 2
}

public enum EResultType:i64{
	Enumerable_IWordWeightResult = 1
	,AsyncEnumerable_IWordWeightResult =2
}


public partial interface ICfgWeightResult{

	public ESortBy SortBy{get;set;}
	#if Impl
		= ESortBy.Weight;
	#endif
	public EResultType ResultType{get;set;}
	#if Impl
		= EResultType.Enumerable;
	#endif
	// public bool UseAsyncEnumerable{get;set;}
	// #if Impl
	// 	= false;
	// #endif
}
