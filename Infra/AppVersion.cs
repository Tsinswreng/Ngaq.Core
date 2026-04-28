namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2026-04-28T23:30:39.708+08:00_W18-2
	//2026_0428_233039
	public Version Ver {get;} = new (1, 2, 0, 261822330);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 2, 0, 261822330);
}

