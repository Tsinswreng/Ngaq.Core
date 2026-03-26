namespace Ngaq.Core.Word.Svc;

using System.Collections;
using System.Runtime.CompilerServices;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Weight;
using Tsinswreng.CsTools;



public partial interface IWeightCalctr{
	public Task<IWeightResult> CalcAsy(
		IAsyncEnumerable<IWordForLearn> Word
		,IJsonNode? CalcArg
		,CT Ct
	);

}
