namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-04T21:16:20.830+08:00_W45-2
	public Version Ver { get; set; } = new (1, 0, 0, 0);
}
