namespace Ngaq.Core.Infra;

using System.Text.Json.Serialization;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Shared.User.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Sys.Models;
using Ngaq.Core.Tools;
using Tsinswreng.CsIfaceGen;


interface INull{

}

//JsonSerializable註解須寫在一起、不能散落在分散之partial class、否則json源生成器不輸出
//執行Ngaq.Core\GenAppJsonCtx.sh㕥自動生成帶註解ʹAppJsonCtx分部類
[IfaceGen(
	ParentType = typeof(IAppSerializable)
	//ParentType = typeof(INull)
	,Name = nameof(IAppSerializable)
	,OutDir = CfgIfaceGen.OutDir+nameof(IAppSerializable)
	,PhFullType = "TYPE"
	,PhIdentifierSafeFullType = "ID"
	,Template =
"""

[JsonSerializable(typeof(TYPE))]
[JsonSerializable(typeof(global::System.Collections.Generic.IList<TYPE>))]

"""

)]
public interface IIfaceGenCfg_AppJsonCtx{

}

[IfaceGen(
	ParentType = typeof(IDictSerializable)
	//ParentType = typeof(INull)
	,Name = nameof(IDictSerializable)
	,OutDir = CfgIfaceGen.OutDir+nameof(IDictSerializable)
	,PhFullType = "TYPE"
	,PhIdentifierSafeFullType = "ID"
	,Template =
"""
typeof(global::Ngaq.Core.Tools.JsonConvtr<TYPE>),

"""

)]
public interface IIfaceGenCfg_JsonCustomConverter{

}

/// <summary>
/// ASP.net 內置Json序列化器專用。
/// 縱既配opt =>opt.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonCtx.Default);
/// 猶需手上 opt.SerializerOptions.Converters.Add(new MyConverter()......)
/// 佢不認AppJsonCtx中 用註解配˪ʹ Converters
/// </summary>
[IfaceGen(
	ParentType = typeof(IDictSerializable)
	//ParentType = typeof(INull)
	,Name = nameof(IDictSerializable)+"List"
	,OutDir = CfgIfaceGen.OutDir+nameof(IDictSerializable)+"List"
	,PhFullType = "TYPE"
	,PhIdentifierSafeFullType = "ID"
	,Template =
"""
new global::Ngaq.Core.Tools.JsonConvtr<TYPE>(),

"""

)]
public interface IIfaceGenCfg_JsonCustomConverterList{

}



// [JsonSourceGenerationOptions(
// 	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
// 	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
// 	,Converters = [
// 		typeof(global::Ngaq.Core.Tools.JsonConvtr<IdKv>)
// 		,typeof(JsonConvtr<IdUser>)
// 		,typeof(JsonConvtr<IdDel>)
// 		,typeof(JsonConvtr<Tempus>)
// 		,
// 	]
// )]
public partial class AppJsonCtx : JsonSerializerContext {
	// public static IList<JsonConverter> JsonConverters = [
	// 	new global::Ngaq.Core.Tools.JsonConvtr<IdKv>(),
	// ];
}
