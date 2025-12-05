namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-12-03T23:23:09.205+08:00_W49-3
	//2025-12-03T23:23:09.205+08:00_W49-3
	public Version Ver {get;} = new (1, 0, 6, 254932323);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 0, 1, 254922317);
}

