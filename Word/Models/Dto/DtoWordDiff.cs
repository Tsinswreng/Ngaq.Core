using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Word.Models.Po.Learn;

namespace Ngaq.Core.Word.Models.Dto;

public partial struct DtoWordDiff{
	public IList<PoWordProp> PoWordProps{get;set;}
	public IList<PoWordLearn> PoWordLearns{get;set;}
}
