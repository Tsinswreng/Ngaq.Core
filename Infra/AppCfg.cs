namespace Ngaq.Core.Infra;


public class AppCfg{
	protected static AppCfg? _Inst = null;
	public static AppCfg Inst => _Inst??= new AppCfg();

	public str SqlitePath{get;set;} = "./Ngaq.Sqlite";
	public str? GalleryDir{get;set;}
}
