namespace Ngaq.Core.Shared.StudyPlan.Models.PreFilter;
[DoNotRenameMembers]
public enum EFilterOperationMode{
	//無效值
	Null=0,
	IncludeAny,
	IncludeAll,
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
