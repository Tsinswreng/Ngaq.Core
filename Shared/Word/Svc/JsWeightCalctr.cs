using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.Models.Weight;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Jint;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tsinswreng.CsTools;

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
		IAsyncEnumerable<IWordForLearn> Word,
		IDictionary<str, obj?>? CalcArg,
		CT Ct
	){
		var calcArgNode = new JsonNode(CalcArg);
		return Calc(Word, calcArgNode, Ct);
	}

	public async Task<IWeightResult> Calc(
		IAsyncEnumerable<IWordForLearn> Word,
		IJsonNode? CalcArg,
		CT Ct
	){
		var words = await Word.ToListAsync(Ct);

		str wordsJson;
		if(words.Count == 0){
			wordsJson = "[]";
		}else{
			wordsJson = JsonSerializer.Stringify(words);
		}

		var engine = new Engine();
		engine.SetValue("WordsJson", wordsJson);
		engine.SetValue("CalcArgJson", CalcArg is null ? "null" : JsonSerializer.Stringify(CalcArg));

		var result = engine.Evaluate(JsCode);
		var resultJson = result.ToString() ?? "";
		var jsWeightResult = JsonSerializer.Parse<JsWeightResult>(resultJson)
			?? throw new InvalidOperationException("JS weight calculator returned null/empty JSON object.");

		return jsWeightResult.ToWeightResult();
	}
}

public partial class JsWeightResult : IAppSerializable{
	[Doc(@$"Option")]
	public OptWeightResult Opt { get; set; } = new OptWeightResult();

	[Doc(@$"Results of each word")]
	public IList<WordWeightResult>? Results { get; set; }

	public IDictionary<str, obj?>? Props { get; set; }

	public IWeightResult ToWeightResult(){
		var opt = new OptWeightResult{
			SortBy = Opt.SortBy,
			ResultType = EResultType.AsyEIWordWeightResult,
		};

		var results = Results ?? new List<WordWeightResult>();
		return new WeightResult{
			Opt = opt,
			Results = results.Cast<IWordWeightResult>().ToAsyncEnumerable(),
			Props = Props,
		};
	}
}
