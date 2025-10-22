using Tsinswreng.CsTools;

namespace Ngaq.Core.FrontendIF;

public  partial interface IImgGetter{
public enum EType{
	Stream = 1
}
	IEnumerable<ITypedObj> GetN(u64 n);
}


