namespace Ngaq.Core.Infra.Errors;
public  partial class EnumErr{
	public static IAppErr Mk(str Id, str? Ns = null){
		var R = new ErrApp{
			Id = Id
			,Namespace = Ns
		};
		ErrMgr.Inst.Register(Id,Ns);
		return R;
	}
}


