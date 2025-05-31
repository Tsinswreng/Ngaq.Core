namespace Ngaq.Core.Model.Po.Kv;

public class ConstLearn{
	protected static ConstLearn? _Inst = null;
	public static ConstLearn Inst => _Inst??= new ConstLearn();

	public str add = nameof(add);
	public str rmb = nameof(rmb);
	public str fgt = nameof(fgt);

}

[Obsolete("Use ConstLearn instead of Const_Learn")]
public class Const_Learn{
	public const str add = nameof(add);
	public const str rmb = nameof(rmb);
	public const str fgt = nameof(fgt);
}
