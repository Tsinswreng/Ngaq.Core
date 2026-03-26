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

[Doc(@$"Jint Js引擎 權重算法。Js代碼來自用戶編寫。")]
public class JsWeightCalctr : IWeightCalctr{
	public IJsonSerializer JsonSerializer { get; set; }
	public str JsCode { get; set; }
	public JsWeightCalctr(IJsonSerializer jsonSerializer, str jsCode){
		JsonSerializer = jsonSerializer;
		JsCode = jsCode;
	}
	
	public Task<IWeightResult> Calc(
		IAsyncEnumerable<IWordForLearn> Word
		,IDictionary<str, obj?>? CalcArg
		,CT Ct
	){
		var calcArgNode = new JsonNode(CalcArg);
		return Calc(Word, calcArgNode, Ct);
	}

	public async Task<IWeightResult> Calc(
		IAsyncEnumerable<IWordForLearn> Word
		,IJsonNode? CalcArg
		,CT Ct
	){
		// Convert async enumerable to list for JSON serialization
		var words = await Word.ToListAsync(Ct);

		// Serialize words to JSON
		str wordsJson;
		if(words.Count == 0){
			wordsJson = "[]";
		}else{
			try{
				wordsJson = JsonSerializer.Stringify(words);
			}catch{
				wordsJson = "[]";
			}
		}

		// Create Jint engine
		var engine = new Engine();

		// Set up input data in the engine
		engine.SetValue("WordsJson", wordsJson);
		if (CalcArg != null) {
			str calcArgJson;
			try{
				calcArgJson = JsonSerializer.Stringify(CalcArg);
			}catch{
				calcArgJson = "null";
			}
			engine.SetValue("CalcArgJson", calcArgJson);
		} else {
			engine.SetValue("CalcArgJson", "null");
		}

		// Execute user-provided JavaScript code
		// The JS code should return a JSON string containing an array of weight results
		var result = engine.Evaluate(JsCode);
		var resultJson = result.ToString();

		// Deserialize results
		List<WordWeightResult> weightResults;
		try{
			weightResults = JsonSerializer.Parse<List<WordWeightResult>>(resultJson) ?? new List<WordWeightResult>();
		}catch{
			var trimmed = (resultJson ?? "").Trim();
			if(trimmed == "[]" || string.IsNullOrEmpty(trimmed)){
				weightResults = new List<WordWeightResult>();
			}else{
				throw;
			}
		}

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

