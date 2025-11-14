namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-14T22:55:37.127+08:00_W46-5
	//2025_1114_225537
	public Version Ver { get; set; } = new (1, 0, 4, 254652255);
}
