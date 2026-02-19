namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2026-01-19T22:38:16.428+08:00_W4-1
	//
	public Version Ver {get;} = new (1, 1, 0, 260412238);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 1, 0, 260412238);
}

