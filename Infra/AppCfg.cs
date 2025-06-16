// using Ngaq.Core.Tools;
// using YamlDotNet.Serialization;

// namespace Ngaq.Core.Infra;

// [Obsolete]
// public class AppCfg{
// 	protected static AppCfg? _Inst = null;
// 	public static AppCfg Inst{
// 		get{
// 			return _Inst??= new AppCfg();
// 		}
// 		set{
// 			_Inst = value;
// 		}
// 	}
// 	public str SqlitePath{get;set;} =
// 	#if DEBUG
// 	"./Ngaq.dev.sqlite"
// 	#else
// 	"./Ngaq.sqlite"
// 	#endif
// 	;
// 	public str? GalleryDir{get;set;}
// }


// [Obsolete]
// public class AppCfgParser{
// protected static AppCfgParser? _Inst = null;
// public static AppCfgParser Inst => _Inst??= new AppCfgParser();

// 	//public IDeserializer Deserializer{get;} = new StaticDeserializerBuilder(new AppYamlCtx()).Build();
// 	[Obsolete]
// 	public AppCfg FromYaml(str yamlStr){
// //尋不見yaml庫芝支持AOT者
// 		throw new NotImplementedException();
// 		// var YamlCtx = new AppYamlCtx();
// 		// var DeserializerBld = new StaticDeserializerBuilder(YamlCtx);
// 		// IDeserializer Deserializer = DeserializerBld.Build();
// 		// return Deserializer.Deserialize<AppCfg>(yamlStr);
// 	}

// 	public AppCfg FromJson(str Json){
// 		return JSON.parse<AppCfg>(Json);

// 	}
// }
