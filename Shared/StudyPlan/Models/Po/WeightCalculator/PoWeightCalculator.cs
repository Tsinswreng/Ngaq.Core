using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.User.Models.Po.User;

namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;


[Doc($@"權重算法持久化實體")]
public class PoWeightCalculator
	:PoBase
	,AppI_Id<IdWeightCalculator>
	,I_Owner
	,I_UniqName
{
	[Doc($@"主鍵")]
	public IdWeightCalculator Id{get;set;} = new();
	[Doc($@"擁有者")]
	public IdUser Owner{get;set;} = IdUser.Zero;
	[Doc($@"用戶側唯一名")]
	public str? UniqName{get;set;} = null;
	[Doc($@"算法實現類型")]
	public EWeightCalculatorType Type{get;set;} = EWeightCalculatorType.Unknown;
	[Doc($@"算法載荷，可為腳本或二進制.
	u8[]便于非文本二進制")]
	public u8[]? Data{get;set;} = null;
	[Doc($@"描述")]
	public str Descr{get;set;} = "";
}

