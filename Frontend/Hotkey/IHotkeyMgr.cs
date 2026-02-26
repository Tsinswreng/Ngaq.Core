namespace Ngaq.Core.Frontend.Hotkey;

/// <summary>
/// 快捷键管理服务
/// 用于注册、注销和管理全局快捷键的生命周期
/// </summary>
public interface IHotkeyMgr{
	/// <summary>
	/// 初始化快捷键系统
	/// </summary>
	public void Init();

	/// <summary>
	/// 注册一个快捷键
	/// </summary>
	public bool Register(str HotkeyId, EHotkeyModifiers Modifiers, EHotkeyKey Key, Func<Task> OnHotkey);

	/// <summary>
	/// 注销一个快捷键
	/// </summary>
	public bool Unregister(str HotkeyId);

	/// <summary>
	/// 关闭快捷键系统并清理资源
	/// </summary>
	public void Shutdown();
}
