global using Ngaq.Core.Infra;
namespace Ngaq.Core.Infra.Core;

public interface I_Answer<T> {
	public T? Data { get; set; }
	public bool Ok { get; set; }
	public ICollection<object?> Errors { get; set; }
	/// <summary>
	/// 全局狀態碼
	/// 自約定。未必同於Http狀態碼
	/// </summary>
	public i64 Code { get; set; }
	public str? CodeType { get; set; }
}
