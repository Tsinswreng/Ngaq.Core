using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Infra.Cfg;
using Ngaq.Core.Word;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Word.WeightAlgo;
using Tsinswreng.CsCfg;
namespace Ngaq.Core;
public static class DiCore{
	public static IServiceCollection SetUpCore(this IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(AppCfg.Inst);
		z.AddTransient<MgrLearn, MgrLearn>();
		z.AddScoped<IWeightCalctr, SvcWeight>();
		return z;
	}
}
