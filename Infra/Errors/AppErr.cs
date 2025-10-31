namespace Ngaq.Core.Infra.Errors;

using Tsinswreng.CsCfg;


public partial class AppErr
	:Exception
	,IErr
	,IAppErr
{
	public AppErr(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
	public AppErr(){}
	public IErrItem? Type{get;set;}
	public str? Key { get{
		return Type?.GetFullPath();
	} set{} }
	public IList<obj?> Errors { get; set; } = new List<obj?>();
	public ISet<str> Tags{get{
		return Type?.Tags ?? new HashSet<str>();
	}set{}}
	public IList<obj?>? Args { get; set; } = new List<obj?>();

	public static AppErr Mk(IErrItem Key, params obj?[] Args){
		var R = new AppErr();
		R.Type = Key;
		R.Args = Args;
		return R;
	}
}
