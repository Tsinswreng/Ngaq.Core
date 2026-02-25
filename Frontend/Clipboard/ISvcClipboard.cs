namespace Ngaq.Core.Frontend.Clipboard;

public interface ISvcClipboard{
	[Doc(@$"
	#Rtn[null when clipboard content is not string]
	")]
	public str? GetText(CT Ct);
}
