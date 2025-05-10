namespace Ngaq.Core.Infra.Core;

/// <summary>
/// 返值包裝
/// 㕥代模式芝throw 業務異常+try-catch
/// 至于預料外ʹ異常、則猶用throw+try-catch、不用此㕥包㞢
/// </summary>
/// <typeparam name="T"></typeparam>
public interface I_Answer<T> {
	public T? Data { get; set; }
	public bool Ok { get; set; }
	/// <summary>
	/// 可潙string, Exception等
	/// </summary>
	public ICollection<object?> Errors { get; set; }
	/// <summary>
	/// 狀態碼
	/// 自約定。未必同於Http狀態碼
	/// </summary>
	public i64 Code { get; set; }
	/// <summary>
	/// Code之名空間、㕥防Code衝突
	/// </summary>
	public str? CodeType { get; set; }
}
