#if false
	/*
	JS sample:
	const words = JSON.parse(Ngaq.WordsJson ?? "[]");
	const arg = JSON.parse(Ngaq.CalcArgJson ?? "{}");
	const baseWeight = Number(arg.BaseWeight ?? 0);
	const step = Number(arg.Step ?? 1);

	const results = words.map((w, i) => ({
		StrId: String(w.StrId ?? ""),
		Weight: baseWeight + i * step,
		Index: i
	}));

	return JSON.stringify({
		Opt: {
			SortBy: "Weight",
			ResultType: "AsyEIWordWeightResult"
		},
		Results: results,
		Props: {
			Algo: "SampleFromWordsAndArg"
		}
	});
	*/
#endif
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Shared.Word.Models.Weight;
using Ngaq.Core.Infra.Errors;
using Ngaq.Core.Tools.Json;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Jint;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tsinswreng.CsErr;
using Tsinswreng.CsTools;
using Microsoft.Extensions.Logging;

namespace Ngaq.Core.Shared.Word.Svc;

[Doc(@$"Jint Js引擎 權重算法。Js代碼來自用戶編寫。")]
public class JsWeightCalctr : IWeightCalctr{
	public IJsonSerializer JsonSerializer { get; set; }
	public str JsCode { get; set; }
	public ILogger? Logger{get;set;}

	public JsWeightCalctr(IJsonSerializer jsonSerializer, str jsCode){
		JsonSerializer = jsonSerializer;
		JsCode = jsCode;
	}

	public Task<IWeightResult> Calc(
		IAsyncEnumerable<IWordForLearn> Word,
		IJsonNode? CalcArg,
		CT Ct
	){
		throw KeysErr.Word.WeightCalcInvalidAlgorithm.ToErr(
			$"Obsolete overload called: {nameof(Calc)}(IAsyncEnumerable<IWordForLearn>, IJsonNode?, CT). Use IDictionary overload instead."
		);
	}

	public async Task<IWeightResult> Calc(
		IAsyncEnumerable<IWordForLearn> Word,
		IDictionary<str, obj?>? CalcArg,
		CT Ct
	){
		// Js 算法代碼為空屬於可預期業務配置錯誤，直接轉業務異常。
		if(string.IsNullOrWhiteSpace(JsCode)){
			throw KeysErr.Word.JsWeightCalcCodeEmpty.ToErr();
		}

		try{
			var words = await Word.ToListAsync(Ct);

			str wordsJson;
			if(words.Count == 0){
				wordsJson = "[]";
			}else{
				wordsJson = JsonSerializer.Stringify(words);
			}

			var engine = new Engine();
			Action<str>? jsLog = null;
			if(Logger is not null){
				jsLog = message => Logger.LogInformation("[JsWeightCalctr] {JsLog}", message);
			}

			engine.SetValue("Ngaq", new {
				WordsJson = wordsJson,
				CalcArgJson = CalcArg is null ? "null" : JsonSerializer.Stringify(CalcArg),
			});
			engine.SetValue("console", new JsConsoleBridge(jsLog));

			var result = engine.Evaluate(JsCode);
			var resultJson = result.ToString() ?? "";
			if(string.IsNullOrWhiteSpace(resultJson)){
				throw KeysErr.Word.JsWeightCalcReturnedEmpty.ToErr();
			}

			var jsWeightResult = JsonSerializer.Parse<JsWeightResult>(resultJson);
			if(jsWeightResult is null){
				throw KeysErr.Word.JsWeightCalcReturnedInvalidJson.ToErr()
					.AddDebugArgs(resultJson);
			}
			return jsWeightResult.ToWeightResult();
		}catch(OperationCanceledException){
			// 取消不包裝為業務異常，沿用取消語義。
			throw;
		}catch(AppErr){
			// 已是業務異常，不重複包裝。
			throw;
		}catch(Exception e){
			throw KeysErr.Word.JsWeightCalcExecFailed.ToErr()
				.AddErr(e)
				.AddDebugArgs(new {
					JsCode = JsCode,
					HasCalcArg = CalcArg is not null,
				});
		}
	}
}

public class JsConsoleBridge{
	private readonly Action<str>? _log;

	public JsConsoleBridge(Action<str>? log){
		_log = log;
	}

	public void log(params obj?[] args){
		if(_log is null){
			return;
		}

		var msg = string.Join(" ", args.Select(x => x?.ToString() ?? "null"));
		_log(msg);
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
