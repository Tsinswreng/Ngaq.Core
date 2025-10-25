# 蔿䀬ʹ叶˪IAppSerializable之類型 生成DictType註解與JsonSerializable註解
# 需賴Tsinswreng.CsIfaceGen.Cli.exe 欲自編譯㞢則珩../CompileIfaceGenCli.sh
# JsonSerializable註解須寫在一起、不能散落在分散之partial class、否則json源生成器不輸出

mkdir -p Tsinswreng.SrcGen
../Tsinswreng.CsIfaceGen.Cli Ngaq.Core.csproj  Tsinswreng.SrcGen
# > Ngaq.Core/Tsinswreng.SrcGen/AppJsonCtx.g.cs

# 把分散之json序列化註解 集到一個文件中
cd Tsinswreng.SrcGen/Tsinswreng.CsIfaceGen/
OutFile=AppJsonCtx.g.cs

cat > $OutFile <<'EOF'
namespace Ngaq.Core.Infra;
using System.Text.Json.Serialization;
EOF

cat AppJsonCtx/* >> $OutFile

cat >> $OutFile <<'EOF'
public partial class AppJsonCtx{}
EOF

rm AppJsonCtx/*

rm CoreDictMapper.g.cs
cat CoreDictMapper/* >>  CoreDictMapper.g.cs
rm CoreDictMapper/*
