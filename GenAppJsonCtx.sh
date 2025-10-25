# 蔿䀬ʹ叶˪IAppSerializable之類型 生成DictType註解與JsonSerializable註解
# 需賴Tsinswreng.CsIfaceGen.Cli.exe 欲自編譯㞢則珩../CompileIfaceGenCli.sh
# JsonSerializable註解須寫在一起、不能散落在分散之partial class、否則json源生成器不輸出

mkdir -p Tsinswreng.SrcGen
../Tsinswreng.CsIfaceGen.Cli Ngaq.Core.csproj  Tsinswreng.SrcGen
# > Ngaq.Core/Tsinswreng.SrcGen/AppJsonCtx.g.cs

# 把分散之json序列化註解 集到一個文件中
cd Tsinswreng.SrcGen/Tsinswreng.CsIfaceGen/

##
IAppSerializable=IAppSerializable.g.cs

cat > $IAppSerializable <<'EOF'
namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
EOF

cat IAppSerializable/* >> $IAppSerializable

cat >> $IAppSerializable <<'EOF'
public partial class AppJsonCtx{}
EOF

rm IAppSerializable/*
##~

##IDictSerializable
IDictSerializable=IDictSerializable.g.cs

cat > $IDictSerializable <<'EOF'
namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
[JsonSourceGenerationOptions(
	//PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	,Converters = [
EOF

cat IDictSerializable/* >> $IDictSerializable

cat >> $IDictSerializable <<'EOF'
	]
)]
public partial class AppJsonCtx{}
EOF

rm IDictSerializable/*
##~IDictSerializable



##IDictSerializableList
IDictSerializableList=IDictSerializableList.g.cs

cat > $IDictSerializableList <<'EOF'
namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
public partial class AppJsonCtx : JsonSerializerContext {
	public static IList<JsonConverter> JsonConverters = [
EOF

cat IDictSerializableList/* >> $IDictSerializableList

cat >> $IDictSerializableList <<'EOF'
	];
}
EOF

rm IDictSerializableList/*
##~IDictSerializableList



rm CoreDictMapper.g.cs
cat CoreDictMapper/* >>  CoreDictMapper.g.cs
rm CoreDictMapper/*

