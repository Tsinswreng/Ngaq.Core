namespace Ngaq.Core.Infra;

public class AppVersion{
	protected static AppVersion? _Inst = null;
	public static AppVersion Inst => _Inst??= new AppVersion();
	//2025-11-04T21:16:20.830+08:00_W45-2
	public Version Version { get; set; } = new (1, 0, 0, 0);
}
