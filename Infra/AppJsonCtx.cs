namespace Ngaq.Core.Infra;

using System.Text.Json.Serialization;
using Ngaq.Core.Infra.IF;
using Tsinswreng.CsIfaceGen;


interface INull{

}

//JsonSerializable註解須寫在一起、不能散落在分散之partial class、否則json源生成器不輸出
//執行Ngaq.Core\GenAppJsonCtx.sh㕥自動生成帶註解ʹAppJsonCtx分部類
[IfaceGen(
	ParentType = typeof(IAppSerializable)
	//ParentType = typeof(INull)
	,Name = nameof(AppJsonCtx)
	,OutDir = CfgIfaceGen.OutDir+nameof(AppJsonCtx)
	,PhFullType = "TYPE"
	,PhIdentifierSafeFullType = "ID"
	,Template =
"""

[JsonSerializable(typeof(TYPE))]

"""

)]
public interface IIfaceGenCfg_AppJsonCtx{

}


[JsonSourceGenerationOptions(
	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
//,Converters =
)]
public partial class AppJsonCtx : JsonSerializerContext {

}
