namespace Ngaq.Core.Word.Svc;

using System.Collections;
using System.Runtime.CompilerServices;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Weight;




//TODO 允受參數
public partial interface IWeightCalctr{
	// public Task<IEnumerable<WordStrId_Weight>> CalcAsy(
	// 	IEnumerable<IWordForLearn> Words
	// 	,CT Ct
	// );

	// [Obsolete]
	// public Task<IWeightResult> CalcAsy(
	// 	IEnumerable<IWordForLearn> Word
	// 	,IKvNode? CalcArg
	// 	,CT Ct
	// );

	public Task<IWeightResult> CalcAsy(
		IAsyncEnumerable<IWordForLearn> Word
		,IKvNode? CalcArg
		,CT Ct
	);

}
