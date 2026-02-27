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

/// 快捷键定义接口
public interface IHotKey{
	/// 快捷键唯一标识
	str Id { get; set; }
	
	/// 修饰键组合 (Ctrl, Shift, Alt, Win)
	EHotkeyModifiers Modifiers { get; set; }
	
	/// 主键
	EHotkeyKey Key { get; set; }
	
	/// 按键触发时的回调
	FnOnHotKey OnHotkey { get; set; }
}

/// IHotKey 默认实现
public class HotKey : IHotKey {
	public str Id { get; set; } = "";
	public EHotkeyModifiers Modifiers { get; set; }
	public EHotkeyKey Key { get; set; }
	public FnOnHotKey OnHotkey { get; set; } = async(a,b)=>null;
}
