using Ngaq.Core.Shared.Base.Models.Resp;
using Ngaq.Core.Shared.Word.Models;

namespace Ngaq.Core.Shared.Dictionary.Models;

public interface IRespLlmDict{
	public str Head{get;set;}
	public IList<TextedPronunciation> Pronunciations{get;set;}
	public IList<str> Descrs{get;set;}
}


public class RespLlmDict:IRespLlmDict, IResp{
	public str Head{get;set;} = "";
	public IList<TextedPronunciation> Pronunciations{get;set;} = [];
	public IList<str> Descrs{get;set;} = [];
}
