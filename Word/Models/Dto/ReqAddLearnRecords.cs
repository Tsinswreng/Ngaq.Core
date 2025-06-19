using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Po.Learn;

namespace Ngaq.Core.Model.Word.Req;

public struct WordId_PoLearns{
	public IdWord WordId;
	public IEnumerable<PoWordLearn> PoLearns;
}

public struct WordId_LearnRecords{
	public IdWord WordId;
	public IEnumerable<ILearnRecord> LearnRecords;
}
