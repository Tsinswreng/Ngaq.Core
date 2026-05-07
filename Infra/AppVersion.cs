namespace Ngaq.Core.Infra;

[Doc(@"
new Version:(1, 2, 3, 261230102)
版本: 1.2.3
時間: 26年 第12週 週3 01:02
應按 中時區。
")]
public class AppVer{
	protected static AppVer? _Inst = null;
	public static AppVer Inst => _Inst??= new AppVer();
	//2026-05-06T23:43:59.521+08:00_W19-3
	//
	public Version Ver {get;} = new (1, 2, 4, 261931543);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 2, 4, 261931543);
}

