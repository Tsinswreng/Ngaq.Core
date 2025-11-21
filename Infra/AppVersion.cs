namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-21T22:15:06.644+08:00_W47-5
	//2025_1121_221506
	public Version Ver { get; set; } = new (1, 0, 5, 254752215);
}
