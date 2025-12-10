namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-12-06T14:03:51.558+08:00_W49-6
	//
	public Version Ver {get;} = new (1, 0, 6, 254961403);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 0, 1, 254922317);
}

