#define Impl
namespace Ngaq.Core.Word.Models.Weight;
public partial class WeightResult: IWeightResult{
	public ICfgWeightResult Cfg{get;set;}
	#if Impl
		 = new CfgWeightResult();
	#endif
	public object? Results{get;set;}

	public Type? Type{
		get;
		set;
	}
	//用戶自定義
	public i64 TypeCode{
		get{
			return (i64)Cfg.ResultType;
		}
		set{
			Cfg.ResultType = (EResultType)value;
		}
	}
	public obj? Data{
		get{
			return Results;
		}
		set{
			Results = value;
		}
	}
}
