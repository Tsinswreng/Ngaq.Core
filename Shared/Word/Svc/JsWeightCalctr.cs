using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Tsinswreng.CsTools;
using Jint;
using Ngaq.Core.Tools.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Ngaq.Core.Shared.Word.Models.Weight;

namespace Ngaq.Core.Shared.Word.Svc;

public class JsWeightCalctr : IWeightCalctr{
	public IJsonSerializer JsonSerializer { get; set; }

	public str JsCode { get; set; }

	public JsWeightCalctr(IJsonSerializer jsonSerializer, str jsCode){
		JsonSerializer = jsonSerializer;
		JsCode = jsCode;
	}

	public async Task<IWeightResult> CalcAsy(
		IAsyncEnumerable<IWordForLearn> Word
		,IJsonNode? CalcArg
		,CT Ct
	){
		// Convert async enumerable to list for JSON serialization
		var words = await Word.ToListAsync(Ct);

		// Serialize words to JSON
		var wordsJson = JsonSerializer.Stringify(words);

		// Create Jint engine
		var engine = new Engine();

		// Set up input data in the engine
		engine.SetValue("WordsJson", wordsJson);
		if (CalcArg != null) {
			var calcArgJson = JsonSerializer.Stringify(CalcArg);
			engine.SetValue("CalcArgJson", calcArgJson);
		} else {
			engine.SetValue("CalcArgJson", "null");
		}

		// Execute user-provided JavaScript code
		// The JS code should return a JSON string containing an array of weight results
		var result = engine.Evaluate(JsCode);
		var resultJson = result.ToString();

		// Deserialize results
		var weightResults = JsonSerializer.Parse<List<WordWeightResult>>(resultJson) ?? new List<WordWeightResult>();

		// Create WeightResult
		var cfg = new OptWeightResult {
			ResultType = EResultType.AsyEIWordWeightResult,
			SortBy = ESortBy.Weight
		};

		return new WeightResult {
			Opt = cfg,
			Results = weightResults
				.Cast<IWordWeightResult>()
				.ToAsyncEnumerable(),
		};
	}
}

