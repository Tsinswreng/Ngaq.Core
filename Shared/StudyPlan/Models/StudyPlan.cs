using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Shared.StudyPlan.Models;

[Doc($$"""
#Sum[學習方案聚合模型]
#Descr[聚合一套學習方案在運行期所需的持久化實體、業務模型與權重參數。]
""")]
public class BoStudyPlan{
	
	[Doc($@"學習方案實體")]
	public PoStudyPlan? PoStudyPlan{get;set;} = null;
	[Doc($@"前置篩選器實體")]
	/// 數據庫實體
	public PoPreFilter? PoPreFilter{get;set;} = null;
	[Doc($@"前置篩選器業務模型")]
	/// 業務模型
	public PreFilter.PreFilter? PreFilter{get;set;} = null;

	[Doc($@"權重算法實體")]
	public PoWeightCalculator? PoWeightCalculator{get;set;} = null;
	[Doc($@"運行期權重算法實例")]
	public IWeightCalctr? WeightCalctr{get;set;} = null;

	[Doc($@"權重參數實體")]
	public PoWeightArg? PoWeightArg{get;set;} = null;

	[Doc($@"反序列化後的權重參數節點")]
	public IJsonNode? WeightArg{get;set;} = null;

}


