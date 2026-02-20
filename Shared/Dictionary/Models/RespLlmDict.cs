using Ngaq.Core.Shared.Word.Models;

namespace Ngaq.Core.Shared.Dictionary.Models;

public class RespLlmDict{
	public str Head{get;set;} = "";
	public IList<TextedPronunciation> Pronunciations{get;set;} = [];
	public IList<str> Descrs{get;set;} = [];
}
