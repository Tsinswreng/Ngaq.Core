using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Word.Models.Learn_;

public class ELearn{
	protected static ELearn? _Inst = null;
	public static ELearn Inst => _Inst??= new ELearn();

	public Learn Add = ConstLearn.Inst.add;
	public Learn Rmb = ConstLearn.Inst.rmb;
	public Learn Fgt = ConstLearn.Inst.fgt;

}

