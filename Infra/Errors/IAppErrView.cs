namespace Ngaq.Core.Infra.Errors;
using Ngaq.Core.Infra.IF;

/// <summary>
/// 常用于 包于列表ⁿ返前端。不含I_Errors, IErrItem
/// 勿蔿佢叶IAppSerializable、緣有自定義異常類 恐 同時繼承Exception及叶斯接口
/// </summary>
public interface IAppErrView:IErr,I_Tags{
	public str? Key{get;set;}
	public IList<obj?> Args { get; set; }
}
