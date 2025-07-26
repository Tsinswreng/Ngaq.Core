#define Impl
using System.Runtime.CompilerServices;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Word.WeightAlgo.Models;

public  partial class WeightWord
	: IWeightWord
{

	public static IWeightWord FromWordForLearn(IWordForLearn Word){
		return Unsafe.As<IWeightWord>(Word);
		//return (IWeightWord)Word.ShallowCloneSelf();
	}

	public IdWord Id {get;set;}
	public f64? Weight {get;set;}
	public IDictionary<str, IList<IProp>> StrKey_Props{get;set;}
	#if Impl
	= new Dictionary<str, IList<IProp>>();
	#endif
	public IList<ILearnRecord> LearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif
	public IList<ILearnRecord> PrevTurnLearnRecords{get;set;}
	#if Impl
	= new List<ILearnRecord>();
	#endif

	// void test(){
	// 	IWeightWord w = new WordForLearn(null);
	// }
}
