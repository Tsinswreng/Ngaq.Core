namespace Ngaq.Core.Infra.Errors;

public partial interface IErrI18n{
	public str Parse(object? err);
}
#if false
TODO 本地化錯ʹ訊 尤帶參數者
註冊參數

public partial class ErrI18n:IErrI18n{
	public str En = "ParseError at File: {0} Line: {1} Column: {2} Unexpected EOF";
	public str Zh = "文件: {0} 行: {1} 列: {2} 意外的结束符";

}
#endif

