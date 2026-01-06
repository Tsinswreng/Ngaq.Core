using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;

public class PoWeightArg
	:PoBaseBizTime
	,I_Id<IdWeightArg>
	,I_Owner
{
	public IdWeightArg Id{get;set;} = new();
	public IdUser Owner{get;set;} = IdUser.Zero;
	public str? UniqueName{get;set;} = null;

	public EWeightArgType Type{get;set;} = EWeightArgType.Json;
	/// <summary>
	/// u8[]便于非文本二進制
	/// 權重算法參數與權重算法相關、故無需如PoPreFilter之存其結構ʹ版本號
	/// </summary>
	public u8[]? Data{get;set;} = null;

	[See(nameof(PoWeightCalculator.UniqueName))]
	public str WeightCalculatorName{get;set;} = "";

	public str Descr{get;set;} = "";
}

