namespace Ngaq.Core.Frontend.Hotkey;

public interface IReqHotKey{
	
}

public class ReqHotKey:IReqHotKey{
	
}

public interface IRespHotKey{
	
}

public class RespHotKey:IRespHotKey{
	
}

public delegate Task<IRespHotKey?> FnOnHotKey(
	IReqHotKey? Req, CT Ct
);

public interface IHotKey{
	public str Name{get;set;}
	public FnOnHotKey FnOnHotKey{get;set;}
}
