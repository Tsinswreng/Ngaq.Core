using System.Collections;
using System.Runtime.CompilerServices;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Weight;

namespace Ngaq.Core.Word.Svc;



public  partial interface IWeightCalctr{
	// public Task<IEnumerable<WordStrId_Weight>> CalcAsy(
	// 	IEnumerable<IWordForLearn> Words
	// 	,CT Ct
	// );

	public Task<IWeightResult> CalcAsy(
		IEnumerable<IWordForLearn> Word
		,CT Ct
	);

}
