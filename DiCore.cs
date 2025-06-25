using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Infra.Cfg;
using Tsinswreng.CsCfg;
namespace Ngaq.Core;

public class DiCore{
	public static IServiceCollection SetUpCore(IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(LocalCfg.Inst);
		return z;
	}
}
