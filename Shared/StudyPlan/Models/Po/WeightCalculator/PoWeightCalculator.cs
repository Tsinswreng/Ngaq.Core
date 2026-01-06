
using Ngaq.Core.Model.Po;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;


public class PoWeightCalculator
	:PoBase
	,I_Id<IdWeightCalculator>
	,I_Owner
{
	public IdWeightCalculator Id{get;set;} = new();
	public IdUser Owner{get;set;} = IdUser.Zero;
	public str? UniqueName{get;set;} = null;
	public EWeightCalculatorType Type{get;set;} = EWeightCalculatorType.Unknown;
	/// <summary>
	/// u8[]便于非文本二進制
	/// </summary>
	public u8[]? Data{get;set;} = null;
	public str Descr{get;set;} = "";
}

