file class DirDoc{
	str Doc =
$$"""
#Sum[

]
#Descr[
单词学习系统代码（Ngaq.Core/Shared/Word模块），包含单词模型定义、学习记录管理、权重计算、文本解析、服务接口等

这套代码是一个面向单词学习场景的领域层核心实现，主要分为以下6大核心模块：

#### 1. 核心数据模型层
- **单词聚合根（JnWord）**：作为单词的核心聚合根，整合了`PoWord`（单词基础信息）、`PoWordProp`（单词属性，如释义、备注）、`PoWordLearn`（学习记录），实现了深克隆、ID重置、按时间/ID对比差异、同步等核心能力。
- **学习用单词（WordForLearn）**：对`JnWord`的封装，适配学习场景，包含权重（Weight）、索引（Index）、已保存/未保存学习记录、上轮学习记录等字段，支持属性变更通知（INotifyPropertyChanged）。
- **学习记录（LearnRecord/ILearnRecord）**：定义学习行为（Add/Rmb/Fgt：添加/记住/忘记）和时间戳，支持与数据库实体（PoWordLearn）的互相转换。

#### 2. 权重计算模块
- **核心接口（IWeightCalctr）**：定义异步权重计算契约，支持传入异步单词列表、计算参数、取消令牌。
- **并行权重计算器（WeightCalculator）**：基于Channel和Parallel.ForEachAsync实现并行权重计算，支持多线程处理，提升计算效率。
- **单单词计算器（CalculatorForOne）**：实现单个单词的权重计算逻辑，核心规则包括：
  - 基于添加次数（AddCnt）的加成系数；
  - 基于时间间隔的记忆（Rmb）减权/忘记（Fgt）加权；
  - 末次添加时间的额外加成；
  - 长时间未复习的权重惩罚。
- **JS扩展权重计算（JsWeightCalctr）**：支持通过JS脚本自定义权重计算逻辑，实现权重算法的灵活扩展。

#### 3. 单词文本解析模块
- **WordListParser**：解析特定格式的单词表文本，支持的格式包含：
  - 元数据块（<metadata>）：定义语言、单词分隔符；
  - 日期块（[日期]）：按日期分组单词；
  - 属性块（[[键|值]]）：单词/日期块的附加属性；
  - 单词块（{单词内容}）：单词的核心内容（词头、释义）。
- **ParseResultMapper**：将解析结果映射为`JnWord`对象，适配数据模型层。

#### 4. 学习状态管理模块
- **MgrLearn**：学习流程的核心管理器，负责：
  - 加载单词并计算权重（LoadEtCalcWeight）；
  - 学习/撤销学习操作（LearnOrUndo）；
  - 保存学习记录到服务（Save）；
  - 管理学习状态（StateLearnWords）：待学习单词列表、已学习单词管理器、操作状态（加载/启动/保存）。
- **MgrLearnedWords**：管理已学习单词的分组（按学习类型ELearn），提供添加/删除/查询已学习单词的能力。

#### 5. 服务接口层
- **ISvcWord**：单词核心服务接口，定义单词的增删改查、批量添加、同步、压缩打包/解包等能力。
- **ISvcParseWordList**：单词表解析服务接口，支持从文件、URL、文本流解析单词。
- **IWeightCalctr**：权重计算服务接口，为权重算法提供统一契约。

#### 6. 数据传输对象（DTO）
- 定义请求/响应模型：如`ReqPackWords`（单词打包请求）、`RespScltWordsOfLearnResultByTimeInterval`（按时间区间查询学习记录响应）、`DtoCompressedWords`（压缩单词传输对象）等。
- 定义枚举：如`ELearn`（学习类型）、`ESortBy`（排序方式）、`EResultType`（权重结果类型）等。

### 核心代码特点
1. **领域驱动设计（DDD）**：
   - 聚合根（JnWord）封装了单词的核心行为（深克隆、差异对比、同步）；
   - 领域服务（MgrLearn）封装学习流程的核心业务逻辑；
   - 接口隔离：如IWeightCalctr隔离权重计算的不同实现（本地C#/JS脚本）。

2. **异步编程**：
   - 大量使用`async/await`、`IAsyncEnumerable`实现异步流处理；
   - 并行计算（Parallel.ForEachAsync）+ 通道（Channel）实现高效的权重计算。

3. **扩展性**：
   - 权重计算支持JS脚本扩展（JsWeightCalctr）；
   - 解析器支持自定义格式扩展；
   - 服务接口抽象，便于不同实现（如本地/远程服务）。

]
""";
}
