namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-13T22:47:27.049+08:00_W46-4
	//2025_1113_224727
	public Version Ver { get; set; } = new (1, 0, 3, 254642247);
}
