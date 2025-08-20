using System.Runtime.CompilerServices;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Word.WeightAlgo.Models;

namespace Ngaq.Core.Word.WeightAlgo;

public  partial class WeightCalculator : IWeightCalctr{

	public async Task<IWeightResult> CalcAsy(
		IEnumerable<IWordForLearn> Words
		,CT Ct
	){
		var R = new WeightResult();
		var Cfg = new CfgWeightResult();
		Cfg.ResultType = EResultType.AsyncEnumerable;
		Cfg.SortBy = ESortBy.Weight;
		R.Cfg = Cfg;
		R.Results = _CalcAsyE(Words, Ct);
		return R;
	}


	protected async IAsyncEnumerable<IWordWeightResult> _CalcAsyE(
		IEnumerable<IWordForLearn> Words
		,[EnumeratorCancellation] CT Ct
	) {
		var ForOne = new CalculatorForOne();
		//var R = new List<WordStrId_Weight>();
		foreach(var Word in Words){
			if(
				Word.PrevTurnLearnRecords.Count == 0
				&& Word.Weight != null
			){
				continue;
			}
			var U = new WordWeightResult();
			ForOne.Init(WeightWord.FromWordForLearn(Word));
			await ForOne.RunAsy(Ct);
			U.StrId = Word.Id.ToString();
			U.Weight = ForOne.WordState.Weight;
			yield return U;
			// R.Add(U);
			// yield return R;
		}
	}
}
