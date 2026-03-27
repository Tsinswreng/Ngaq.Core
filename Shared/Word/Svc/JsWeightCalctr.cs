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
using System.Collections;
using WR = Ngaq.Core.Word.Models.Weight.IWeightResult;
using WWR = Ngaq.Core.Word.Models.Weight.IWordWeightResult;
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
		var resultJson = result.ToString() ?? "";
		var resultDict = ToolJson.JsonStrToDict(resultJson)
			?? throw new InvalidOperationException("JS weight calculator returned null/empty JSON object.");
		//TODO 定義業務異常
		var mapped = MapDictToWeightResult(resultDict);
		var cfg = mapped.Opt ?? new OptWeightResult();
		cfg.ResultType = EResultType.AsyEIWordWeightResult;
		mapped.Opt = cfg;
		return mapped;
	}

	private static WeightResult MapDictToWeightResult(IDictionary<str, obj?> src){
		var opt = new OptWeightResult {
			ResultType = EResultType.AsyEIWordWeightResult,
			SortBy = ESortBy.Weight
		};
		
		var optDict = src.GetValueByPath([nameof(WR.Opt)]) as IDictionary<str, obj?>;
		if(optDict is not null){
			opt.SortBy = Enum.Parse<ESortBy>(optDict[nameof(IOptWeightResult.SortBy)]+"");
			// Results is always adapted to async enumerable in this calculator.
			opt.ResultType = EResultType.AsyEIWordWeightResult;
		}

		var results = ParseResults(src);
		var propsDict = src.GetValueByPath([nameof(WR.Props)]) as IDictionary<str, obj?>;
		var props = propsDict is not null
			? new Dictionary<str, obj?>(propsDict)
			: null;

		return new WeightResult{
			Opt = opt,
			Results = results.Cast<WWR>().ToAsyncEnumerable(),
			Props = props
		};
	}

	private static List<WordWeightResult> ParseResults(IDictionary<str, obj?> src){
		var raw = src.GetValueByPath([nameof(WR.Results)]);
		if(raw is null || raw is not IEnumerable list || raw is str){
			return new List<WordWeightResult>();
		}

		var ans = new List<WordWeightResult>();
		foreach(var item in list){
			if(item is IDictionary<str, obj?> itemDict){
				var one = new WordWeightResult{
					StrId = itemDict[nameof(WWR.StrId)]?.ToString() ?? "",
					Weight = Convert.ToDouble(itemDict[nameof(WWR.Weight)]),
					Index = Convert.ToUInt64(itemDict[nameof(WWR.Index)]),
				};
				ans.Add(one);
			}
		}
		return ans;
	}

}
