namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
[DoNotRenameMembers]
public enum EFilterOperationMode{
	//無效值
	Null=0,
	///Lang IncludeAny [en, jp] -> Lang == 'en' OR Lang == 'jp'
	IncludeAny,
	/// Lang IncludeAll [en, jp] -> Lang == 'en' AND Lang == 'jp'
	IncludeAll,
	/// 暫不設 ExcludeAny
	ExcludeAll,
	/// >
	Gt,
	/// >=
	Ge,
	/// <
	Lt,
	/// <=
	Le,
	/// =     Eq Null -> `IS NULL`
	Eq,
	/// !=    Ne Null -> `IS NOT NULL`
	Ne,
}
