using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightArg;

[Doc($@"權重算法參數持久化實體")]
public class PoWeightArg
	:PoBaseBizTime
	,AppI_Id<IdWeightArg>
	,I_Owner
{
	[Doc($@"主鍵")]
	public IdWeightArg Id{get;set;} = new();
	[Doc($@"擁有者")]
	public IdUser Owner{get;set;} = IdUser.Zero;
	[Doc($@"用戶側唯一名")]
	public str? UniqName{get;set;} = null;

	[Doc($@"參數數據格式")]
	public EWeightArgType Type{get;set;} = EWeightArgType.Json;
	
	[Doc($@"參數載荷")]
	/// u8[]便于非文本二進制
	/// 權重算法參數與權重算法相關、故無需如PoPreFilter之存其結構ʹ版本號
	
	public u8[]? Data{get;set;} = null;

	[Doc($@"關聯算法名稱，參見 {nameof(PoWeightCalculator.UniqName)}")]
	public str WeightCalculatorName{get;set;} = "";

	[Doc($@"描述")]
	public str Descr{get;set;} = "";
}

