using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public class ELearn{
	protected static ELearn? _Inst = null;
	public static ELearn Inst => _Inst??= new ELearn();

	public Learn Add = ConstLearn.Inst.add;
	public Learn Rmb = ConstLearn.Inst.rmb;
	public Learn Fgt = ConstLearn.Inst.fgt;

}

