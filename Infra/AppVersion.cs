namespace Ngaq.Core.Infra;

public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2025-11-26T11:20:37.504+08:00_W48-3
	//2025_1126_112037
	public Version Ver {get;} = new (1, 0, 5, 254831120);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 0, 0, 254831120);
}

