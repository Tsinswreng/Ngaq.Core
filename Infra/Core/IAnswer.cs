namespace Ngaq.Core.Infra.Core;
using Ngaq.Core.Infra.Errors;



/// <summary>
/// 返值包裝
/// 㕥代模式芝throw 業務異常+try-catch
/// 至于預料外ʹ異常、則猶用throw+try-catch、不用此㕥包㞢
/// </summary>
/// <typeparam name="T"></typeparam>
public partial interface IAnswer<T>
	:ITypedStatus
{
	public T? Data { get; set; }
	public bool Ok { get; set; }
	/// <summary>
	/// 可潙string, Exception等
	/// </summary>
	public ICollection<object?>? Errors { get; set; }
}
