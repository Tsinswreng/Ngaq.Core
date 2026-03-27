using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Shared.User.UserCtx;
using Ngaq.Core.Infra.Cfg;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsCfg;
using Ngaq.Core.Shared.Word;
using Microsoft.Extensions.Logging;
using Ngaq.Core.Shared.Word.WeightAlgo;
using Ngaq.Core.Shared.StudyPlan.Svc;
namespace Ngaq.Core;
public static class DiCore{
	public static IServiceCollection SetupCore(this IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(AppCfg.Inst);
		z.AddTransient<MgrLearn, MgrLearn>();
		z.AddScoped<IWeightCalctr, SvcWeight>();
		z.AddScoped<IStudyPlanGetter, DfltStudyPlanGetter>();
		z.AddTransient<IJsonSerializer, AppJsonSerializer>();

		using var loggerFactory = LoggerFactory.Create(b=>{
			b.AddConsole()
			#if DEBUG
			.SetMinimumLevel(LogLevel.Debug)
			#else
			.SetMinimumLevel(LogLevel.Information)
			#endif
			;
		});
		var Logger = loggerFactory.CreateLogger("GlobalLogger");
		z.AddSingleton<ILogger>(Logger);

		return z;
	}
}
