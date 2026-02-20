using Ngaq.Core.Infra;
using Ngaq.Core.Infra.Cfg;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Tools;
using Tsinswreng.CsDictMapper;
using Tsinswreng.CsYamlMd;

file class DirDoc{
	str Doc =
$"""
#Sum[一種基于大模型的詞典
該詞典與普通的靜態詞典不同、他可以自由指定源語言(查詢的單詞的語言)與目標語言(釋義語言)
有點類似于翻譯、但翻譯是翻譯、我這要做的是詞典]
#Descr[
- 輸入格式{nameof(ReqLlmDict)}
- 輸出格式{nameof(RespLlmDict)}
- 大模型輸出 使用的結構化標記語言格式: YamlMd {nameof(YamlMd.Inst.ToYaml)}
- 序列化 {nameof(ToolYaml.YamlStrToDict)} {nameof(CoreDictMapper)}
- 相關配置{nameof(ItemsClientCfg.LlmDictionary)}
]
""";

}
