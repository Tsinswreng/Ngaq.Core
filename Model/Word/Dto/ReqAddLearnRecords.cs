using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Service.Word.Learn_.Models;

namespace Ngaq.Core.Model.Word.Req;

public struct WordId_PoLearns{
	public IdWord WordId;
	public IEnumerable<PoLearn> PoLearns;
}

public struct WordId_LearnRecords{
	public IdWord WordId;
	public IEnumerable<LearnRecord> LearnRecords;
}
