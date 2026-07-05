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
	public const str IsoTime = "2026-07-04T11:09:15.168+08:00_W27-6";
	public Version Ver {get;} = new (1, 2, 17, 262760309);

	//不涉及前端
	public Version CoreVer{get;} = new (1, 2, 17, 262760309);
}

