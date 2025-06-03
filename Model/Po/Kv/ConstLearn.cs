namespace Ngaq.Core.Model.Po.Kv;

public class ConstLearn{
	protected static ConstLearn? _Inst = null;
	public static ConstLearn Inst => _Inst??= new ConstLearn();

	public str add = nameof(add);
	public str rmb = nameof(rmb);
	public str fgt = nameof(fgt);

}
