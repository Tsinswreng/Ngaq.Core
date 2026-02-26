namespace Ngaq.Core.Frontend.Hotkey;

/// <summary>
/// 全局快捷键监听器接口
/// 支持跨平台注册和监听快捷键
/// </summary>
public interface IHotkeyListener{
	/// <summary>
	/// 注册全局快捷键
	/// </summary>
	/// <param name="HotkeyId">快捷键唯一标识符</param>
	/// <param name="Modifiers">修饰键 (Ctrl, Shift, Alt, Win 的组合)</param>
	/// <param name="Key">主键</param>
	/// <param name="OnHotkey">快捷键被触发时的回调</param>
	/// <param name="Ct">取消令牌</param>
	/// <returns>注册成功返回true</returns>
	public Task<bool> Register(
		str HotkeyId
		, EHotkeyModifiers Modifiers
		, EHotkeyKey Key
		, Func<CT, Task> OnHotkey
		, CT Ct
	);

	/// <summary>
	/// 注销快捷键
	/// </summary>
	/// <param name="HotkeyId">快捷键唯一标识符</param>
	/// <param name="Ct">取消令牌</param>
	/// <returns>注销成功返回true</returns>
	public Task<bool> Unregister(str HotkeyId, CT Ct);

	/// <summary>
	/// 清理所有已注册的快捷键
	/// </summary>
	public Task Cleanup(CT Ct);
}

/// <summary>
/// 快捷键修饰符枚举
/// </summary>
[Flags]
public enum EHotkeyModifiers{
	None = 0,
	Ctrl = 1,
	Shift = 2,
	Alt = 4,
	Win = 8
}

/// <summary>
/// 快捷键枚举
/// </summary>
public enum EHotkeyKey{
	// 字母键
	A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,

	// 数字键
	D0, D1, D2, D3, D4, D5, D6, D7, D8, D9,

	// 功能键
	F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,

	// 特殊键
	Enter,
	Escape,
	Backspace,
	Tab,
	Space,
	Delete,
	Home,
	End,
	PageUp,
	PageDown,
	Up,
	Down,
	Left,
	Right,

	// 其他常用键
	Print,
	Pause,
	Insert,
	NumLock,
	CapsLock,
	ScrollLock
}
