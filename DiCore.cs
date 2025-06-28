using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Infra.Cfg;
using Tsinswreng.CsCfg;
namespace Ngaq.Core;
public static class DiCore{
	public static IServiceCollection SetUpCore(this IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(LocalCfg.Inst);
		return z;
	}
}
