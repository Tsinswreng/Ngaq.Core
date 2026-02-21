namespace Ngaq.Core.Infra.Errors;

using K = Tsinswreng.CsErr.IErrItem;
using static Tsinswreng.CsErr.ErrItem;

[Doc(@$"異常項
內部類按領域劃分
標識符命名 約定 __ 潙參數佔位符
- {nameof(MkB)} 業務異常
")]
public static class ItemsErr{
	public static class Common{
		public static K _R = Mk(null, [nameof(Common)]);
		public static K ArgErr = MkB(_R, [nameof(ArgErr)]);
		public static K UnknownErr = MkB(_R, [nameof(UnknownErr)]);
	}
	public class User{
		public static K _R = Mk(null, [nameof(User)]);
		[Doc(@$"慎用、防止用戶枚舉漏洞")]
		public static K UserNotExist = MkB(_R, [nameof(UserNotExist)]);
		[Doc(@$"慎用、防止用戶枚舉漏洞")]
		public static K UserAlreadyExist = MkB(_R, [nameof(UserAlreadyExist)]);
		public static K PasswordNotMatch = MkB(_R, [nameof(PasswordNotMatch)]);
		public static K InvalidToken = MkB(_R, [nameof(InvalidToken)]);
		public static K TokenExpired = MkB(_R, [nameof(TokenExpired)]);
		public static K AuthenticationFailed = MkB(_R, [nameof(AuthenticationFailed)]);
	}
	public class Word{
		public static K _R = Mk(null, [nameof(Word)]);
		public static K LoadWordListFailed = MkB(_R, [nameof(LoadWordListFailed)]);
		public static K SaveWordListFailed = MkB(_R, [nameof(SaveWordListFailed)]);
		public static K __NotBelongToLang__ = MkB(_R, [nameof(__NotBelongToLang__)]);
		public static K __And__IsNotSameUserWord = MkB(_R, [nameof(__And__IsNotSameUserWord)]);
		public static K BackgroundImageServiceFailedToInit = MkB(_R, [nameof(BackgroundImageServiceFailedToInit)]);
	}

	/// <summary>
	/// 字典服務相關異常
	/// </summary>
	public class Dictionary{
		public static K _R = Mk(null, [nameof(Dictionary)]);
		/// <summary>
		/// LLM 字典 API 未配置（URL 或 Key 缺失）
		/// </summary>
		public static K LlmApiNotConfigured = MkB(_R, [nameof(LlmApiNotConfigured)]);
		/// <summary>
		/// LLM API 返回空響應
		/// </summary>
		public static K LlmApiEmptyResponse = MkB(_R, [nameof(LlmApiEmptyResponse)]);
		/// <summary>
		/// LLM API 響應結構無效
		/// </summary>
		public static K LlmApiInvalidResponseStructure = MkB(_R, [nameof(LlmApiInvalidResponseStructure)]);
		/// <summary>
		/// LLM API 返回空內容
		/// </summary>
		public static K LlmApiEmptyContent = MkB(_R, [nameof(LlmApiEmptyContent)]);
		/// <summary>
		/// 解析 LLM 響應失敗
		/// </summary>
		public static K LlmResponseParseFailed = MkB(_R, [nameof(LlmResponseParseFailed)]);
	}
}
