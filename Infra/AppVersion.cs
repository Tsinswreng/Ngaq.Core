namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-09T11:16:56.192+08:00_W45-7
	public Version Ver { get; set; } = new (1, 0, 0, 25_457_1656);
}
