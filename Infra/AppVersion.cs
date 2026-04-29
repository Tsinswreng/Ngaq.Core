namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2026-04-29T11:06:00.321+08:00_W18-3
	//
	public Version Ver {get;} = new (1, 2, 1, 261831106);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 2, 1, 261831106);
}

