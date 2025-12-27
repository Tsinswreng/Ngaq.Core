namespace Ngaq.Core.Shared.Word.WeightAlgo;

using System.Runtime.CompilerServices;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Weight;
using Ngaq.Core.Word.Svc;
using Ngaq.Core.Word.WeightAlgo.Models;

using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;
using Ngaq.Core.Shared.Word.Models.Learn_;
using Ngaq.Core.Tools.Json;

public partial class WeightCalculator : IWeightCalctr {

	[Impl]
	public async Task<IWeightResult> CalcAsy(
		IAsyncEnumerable<IWordForLearn> Words
		,IKvNode? CalcArg
		,CT Ct
	){
		var cfg = new CfgWeightResult {
			ResultType = EResultType.AsyncEnumerable_IWordWeightResult,
			SortBy = ESortBy.Weight
		};

		// Channel 容量決定背壓，可按實際調整
		var channel = Channel.CreateBounded<IWordWeightResult>(
			new BoundedChannelOptions(Environment.ProcessorCount * 2){//隊列最多能存嘰個結果對象
				SingleWriter = false, SingleReader = true
			}
		);

		// 並行度 == Environment.ProcessorCount 預設即可
		var parallelOptions = new ParallelOptions {
			CancellationToken = Ct,
			MaxDegreeOfParallelism = Environment.ProcessorCount//同時有嘰個綫程
		};

		// 把「計算」放到後台執行
		_ = Task.Run(async () => {
			try {
				await Parallel.ForEachAsync(Words, parallelOptions, async (word, innerCt) => {
					// 快速剪枝
					if (word.PrevTurnLearnRecords.Count == 0 && word.Weight != null){
						return;
					}
					// 每個詞獨立 new CalculatorForOne，保證執行緒安全
					var calc = new CalculatorForOne();
					if(CalcArg is not null){
						calc.Cfg.InitFromKv(CalcArg);
					}
					calc.Init(WeightWord.FromWordForLearn(word));
					await calc.RunAsy(innerCt);

					var result = new WordWeightResult {
						StrId = word.Id.ToString(),
						Weight = calc.WordState.Weight
					};
					await channel.Writer.WriteAsync(result, innerCt);
				});
			}catch(Exception){
				throw;
			}finally {
				channel.Writer.Complete();
			}
		}, Ct);

		return new WeightResult {
			Cfg = cfg,
			Results = ReadResultsAsyE(channel.Reader, Ct),
			Type = typeof(IAsyncEnumerable<IWordWeightResult>)
		};
	}

	// public async Task<IWeightResult> CalcAsy(
	// 	IEnumerable<IWordForLearn> Words,
	// 	CT Ct
	// ){
	// 	return await CalcAsy(Words.ToAsyncEnumerable(), Ct);
	// }

	private static async IAsyncEnumerable<IWordWeightResult> ReadResultsAsyE(
		ChannelReader<IWordWeightResult> reader,
		[EnumeratorCancellation] CT Ct
	){
		await foreach (var item in reader.ReadAllAsync(Ct)){
			yield return item;
		}
	}
}
