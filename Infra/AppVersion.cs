namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-12T12:10:17.197+08:00_W46-3
	public Version Ver { get; set; } = new (1, 0, 2, 254631210);
}
