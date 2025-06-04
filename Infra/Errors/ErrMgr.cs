namespace Ngaq.Core.Infra.Errors;


public class ErrMgr{
	protected static ErrMgr? _Inst = null;
	public static ErrMgr Inst => _Inst??= new ErrMgr();

	public IDictionary<Id_Ns, nil> ErrSet{get;} = new Dictionary<Id_Ns, nil>();
	public nil Register(str Id, str? Ns){
		Id_Ns key = new Id_Ns{Id = Id, Ns = Ns??""};
		if(ErrSet.ContainsKey(key)){
			throw new FatalLogicErr("Error already exists: "+key.ToString());
		}
		ErrSet.Add(key, Nil);
		return Nil;
	}
}
