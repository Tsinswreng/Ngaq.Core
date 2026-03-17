namespace Ngaq.Core.Shared.StudyPlan.Models.Po.WeightCalculator;


[Doc($@"權重算法實現載體類型")]
public enum EWeightCalculatorType{
	[Doc($@"未知")]
	Unknown,
	[Doc($@"命令行程序(暫不支持)")]
	Cli,
	[Doc($@"動態鏈接庫(暫不支持)")]
	Dll,
	[Doc($@"JavaScript 腳本")]
	Js,
}
