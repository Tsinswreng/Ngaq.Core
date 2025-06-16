using Microsoft.Extensions.DependencyInjection;
using Ngaq.Core.Infra.Cfg;
namespace Ngaq.Core;

public class DiCore{
	public static IServiceCollection SetUpCore(IServiceCollection z){
		z.AddSingleton<ICfgAccessor>(AppCfg.Inst);
		return z;
	}
}
