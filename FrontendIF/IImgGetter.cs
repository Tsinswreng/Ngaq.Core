using Tsinswreng.CsCore.Tools;

namespace Ngaq.Core.FrontendIF;

public interface IImgGetter{
public enum EType{
	Stream = 1
}
	ITypedObj GetN(u64 n);
}


