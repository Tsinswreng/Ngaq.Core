using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Model.Word.Req;

public struct WordId_PoLearns{
	public IdWord WordId;
	public IEnumerable<PoLearn> PoLearns;
}

public struct WordId_LearnRecords{
	public IdWord WordId;
	public IEnumerable<ILearnRecord> LearnRecords;
}
