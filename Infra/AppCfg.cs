using YamlDotNet.Serialization;

namespace Ngaq.Core.Infra;


public class AppCfg{
	protected static AppCfg? _Inst = null;
	public static AppCfg Inst{
		get{
			return _Inst??= new AppCfg();
		}
		set{
			_Inst = value;
		}
	}
	public str SqlitePath{get;set;} =
	#if DEBUG
	"./Ngaq.dev.sqlite"
	#else
	"./Ngaq.sqlite"
	#endif
	;
	public str? GalleryDir{get;set;}
}



public class AppCfgParser{
protected static AppCfgParser? _Inst = null;
public static AppCfgParser Inst => _Inst??= new AppCfgParser();

	public IDeserializer Deserializer{get;} = new StaticDeserializerBuilder(new AppYamlCtx()).Build();
	public AppCfg FromYaml(str yamlStr){
		return Deserializer.Deserialize<AppCfg>(yamlStr);
	}
}
