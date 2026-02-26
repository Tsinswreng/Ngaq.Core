namespace Ngaq.Core.Frontend.Hotkey;

/// 快捷键管理服务
/// 用于注册、注销和管理全局快捷键的生命周期
public interface IHotkeyMgr{
	/// 初始化快捷键系统
	public void Init();

	/// 注册一个快捷键
	public bool Register(str HotkeyId, EHotkeyModifiers Modifiers, EHotkeyKey Key, Func<Task> OnHotkey);

	/// 注销一个快捷键
	public bool Unregister(str HotkeyId);

	/// 关闭快捷键系统并清理资源
	public void Shutdown();
}
