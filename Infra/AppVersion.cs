namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-10T22:50:24.951+08:00_W46-1
	public Version Ver { get; set; } = new (1, 0, 1, 254612250);
}
