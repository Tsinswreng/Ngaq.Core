using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Infra.Cfg;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Word.WeightAlgo;
using Tsinswreng.CsCfg;
using Ngaq.Core.Shared.Word;
namespace Ngaq.Core;
public static class DiCore{
	public static IServiceCollection SetupCore(this IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(AppCfg.Inst);
		z.AddTransient<MgrLearn, MgrLearn>();
		z.AddScoped<IWeightCalctr, SvcWeight>();
		z.AddTransient<IJsonSerializer, JsonSerializer>();

		return z;
	}
}
