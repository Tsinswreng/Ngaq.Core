namespace Ngaq.Core.Model;

public struct ExistGroup<T>{
	/// <summary>
	/// 已存在
	/// </summary>
	public IEnumerable<T>? Existings { get; set; }
	/// <summary>
	/// 未存在(待添加)
	/// </summary>
	public IEnumerable<T>? NonExistings { get; set; }
}
