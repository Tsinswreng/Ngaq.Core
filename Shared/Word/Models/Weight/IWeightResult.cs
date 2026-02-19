using Ngaq.Core.Shared.Word.Models.Weight;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Word.Models.Weight;


public partial interface IWeightResult{
	public IOptWeightResult Opt{get;set;}
	#if Impl
		 = new CfgWeight();
	#endif
	public IAsyncEnumerable<IWordWeightResult>? Results{get;set;}
	public IDictionary<str, obj?>? Props{get;set;}
}
