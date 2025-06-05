using System.Collections;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Word.Svc;



public interface IWeightCalctr{
	public Task<IEnumerable<WordStrId_Weight>> CalcAsy(
		IEnumerable<IWordForLearn> Words
		,CT Ct
	);

}
