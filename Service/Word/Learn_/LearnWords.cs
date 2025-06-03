using Ngaq.Core.Service.Word.Learn_.Models;

namespace Ngaq.Core.Service.Word;

public class LearnStatus{
	public bool Load = false;
	public bool Start = false;
	public bool Save = true;
}

public class StateLearnedWords{
	public IDictionary<Learn, IDictionary<IWordToLearn, nil>> Learn_WordSet{get;set;}
	= new Dictionary<Learn, IDictionary<IWordToLearn, nil>>();

	protected IDictionary<IWordToLearn, nil> GetWordSet(Learn Learn){
		if(Learn_WordSet.TryGetValue(Learn, out var WordSet)){
			return WordSet;
		}else{
			WordSet = new Dictionary<IWordToLearn, nil>();
			Learn_WordSet.Add(Learn, WordSet);
			return WordSet;
		}
	}

	public nil Set(
		Learn Learn
		,IWordToLearn Word
	){
		var WordSet = GetWordSet(Learn);
		WordSet[Word] = Nil;
		return Nil;
	}

	public nil Delete(
		Learn Learn
		,IWordToLearn Word
	){
		var WordSet = GetWordSet(Learn);
		if(WordSet.ContainsKey(Word)){
			WordSet.Remove(Word);
		}
		return Nil;
	}


}

public class StateLearnWords{
	public IList<IWordToLearn> WordsToLearn { get; set; } = new List<IWordToLearn>();
	public StateLearnedWords StateLearnedWords { get; set; } = new StateLearnedWords();
	public LearnStatus LearnStatus {get;set;} = new ();

}

public class LearnMgr{
	public StateLearnWords StateLearnWords{get;set;} = new();
}
