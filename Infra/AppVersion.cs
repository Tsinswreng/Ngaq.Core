namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-15T23:09:41.532+08:00_W46-6
	//2025_1115_230941
	public Version Ver { get; set; } = new (1, 0, 5, 254662309);
}
