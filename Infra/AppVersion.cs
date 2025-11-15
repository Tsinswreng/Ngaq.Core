namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-15T21:36:57.096+08:00_W46-6
	//2025_1115_213659
	public Version Ver { get; set; } = new (1, 0, 4, 254662136);
}
