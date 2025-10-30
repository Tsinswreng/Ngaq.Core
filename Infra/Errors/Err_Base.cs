namespace Ngaq.Core.Infra.Errors;

using Tsinswreng.CsCfg;


public partial class ErrBase
	:Exception
	,IErr
	,IAppErr
{
	public ErrBase(string? message, Exception? innerException = null)
		:base(message, innerException)
	{

	}
	public ErrBase(){}
	public str? Id { get; set; }
	public str? Msg { get; set; }
	public IList<obj?> Errors { get; set; } = new List<obj?>();
	public IList<obj?> Args { get; set; } = new List<obj?>();

	public static ErrBase Mk(IErrKeySeg Key, params obj?[] Args){
		var R = new ErrBase();
		R.Id = Key.GetFullPath();
		R.Args = Args;
		return R;
	}

}
