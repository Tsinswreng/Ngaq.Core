using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.StudyPlan.Models.Po.PreFilter;
using Ngaq.Core.Shared.StudyPlan.Models.Po.StudyPlan;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsSql;
using Tsinswreng.CsTools;
namespace Ngaq.Core.Shared.StudyPlan.Models;

[Doc($@"學習方案聚合")]
public class JnStudyPlan
	:IAppSerializable
	,I_ClassVer
	,IAgg
{
	public static Version ClassVer{get;set;} = new Version(1,0);
	[Doc($@"學習方案主體")]
	public PoStudyPlan StudyPlan{get;set;}
	[Doc($@"前置篩選器；可空表示未配置")]
	public PoPreFilter? PreFilter{get;set;} = null;
	[Doc($@"權重算法；可空表示未配置")]
	public PoWeightCalculator? WeightCalculator{get;set;} = null;
	[Doc($@"權重參數；可空表示未配置")]
	public PoWeightArg? WeightArg{get;set;} = null;
}
