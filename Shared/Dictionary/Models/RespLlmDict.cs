using Ngaq.Core.Shared.Base.Models.Resp;

namespace Ngaq.Core.Shared.Dictionary.Models;

[Doc(@$"大模型詞典 查詢結果。
簡易 通用版、不支持按義項區分/獨立例句字段 等
")]
public interface IRespLlmDict{
	public str Head{get;set;}
	[Doc(@$"可能有多種讀音")]
	public IList<TextedPronunciation> Pronunciations{get;set;}
	[Doc(@$"可能有多種、要圖簡便也可以全放首元素裏")]
	public IList<str> Descrs{get;set;}
}


public class RespLlmDict:IRespLlmDict, IResp{
	public str Head{get;set;} = "";
	public IList<TextedPronunciation> Pronunciations{get;set;} = [];
	public IList<str> Descrs{get;set;} = [];
}
