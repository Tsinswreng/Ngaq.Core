namespace Ngaq.Core.Infra.Errors;


public class ErrMgr{
	protected static ErrMgr? _Inst = null;
	public static ErrMgr Inst => _Inst??= new ErrMgr();

	public IDictionary<Id_Ns, nil> ErrSet{get;} = new Dictionary<Id_Ns, nil>();
	public nil Register(str Id, str? Ns){
		Id_Ns key = new Id_Ns{Id = Id, Ns = Ns??""};
		//內部類異常枚舉中 具體異常設計潙工廠函數、每次創建異常對象即註冊一次
		// if(ErrSet.ContainsKey(key)){
		// 	throw new FatalLogicErr("Error already exists: "+key.ToString());
		// }
		//ErrSet.Set(key, Nil);
		ErrSet[key] = NIL;
		return NIL;
	}
}
