namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-12-10T22:10:49.235+08:00_W50-3
	//
	public Version Ver {get;} = new (1, 0, 6, 255032210);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 0, 1, 254922317);
}

