namespace Ngaq.Core.Word.Models.Weight;

public enum ESortBy:i64{
	Weight = 1
	,Pos = 2
}

public enum EResultType:i64{
	Enumerable = 1
	,AsyncEnumerable =2
}

public interface ICfgWeightResult{

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
