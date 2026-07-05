namespace Ngaq.Core.Infra.Log;

using Microsoft.Extensions.Logging;
using Tsinswreng.CsLog;

/// <summary>
/// 全局應用日誌入口。
/// 目標是讓「不方便依賴注入」與「可由 DI 注入」兩種場景都指向同一條日誌出口。
/// </summary>
public class AppLog : DelegatingLogger {
	/// <summary>
	/// 全局唯一實例。各入口程序集只應初始化這一個源頭。
	/// </summary>
	public static AppLog Inst { get; } = new AppLog();

	private static ILoggerFactory? OwnedLoggerFactory { get; set; }

	/// <summary>
	/// 私有構造，避免外部再建立第二個全局源頭。
	/// </summary>
	private AppLog() { }

	/// <summary>
	/// 讓入口程序集把平台實際 logger 接到全局源頭上。
	/// </summary>
	public static void UseLogger(ILogger Logger) {
		Inst.InnerLogger = Logger;
	}

	/// <summary>
	/// 為沒有平台專用 logger 的入口提供一個最小可用的 Console logger。
	/// 這裏持有 factory，是爲了避免 provider 被過早釋放。
	/// </summary>
	public static void UseConsoleLogger(str CategoryName, LogLevel MinLevel) {
		OwnedLoggerFactory = LoggerFactory.Create(Builder => {
			Builder
				.AddConsole()
				.SetMinimumLevel(MinLevel);
		});
		Inst.InnerLogger = OwnedLoggerFactory.CreateLogger(CategoryName);
	}
}
