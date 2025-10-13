using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Word.Models.Learn_;

public enum ELearn{
	Add = 1
	,Rmb = 2
	,Fgt = 3
}

#if false
public partial class OldELearn{
	protected static OldELearn? _Inst = null;
	public static OldELearn Inst => _Inst??= new OldELearn();

	public ELearn Add = ConstLearn.add;
	public ELearn Rmb = ConstLearn.rmb;
	public ELearn Fgt = ConstLearn.fgt;
}


#endif
