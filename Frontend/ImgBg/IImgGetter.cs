namespace Ngaq.Core.Frontend.ImgBg;

using Tsinswreng.CsTools;

public partial interface IImgGetter{
public enum EType{
	Stream = 1
}
	IEnumerable<ITypedObj> GetN(u64 n);
}


