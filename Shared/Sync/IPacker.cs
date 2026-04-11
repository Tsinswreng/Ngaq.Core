using Ngaq.Core.Infra;
using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Kv;
using Tsinswreng.CsErr;
using Tsinswreng.CsTextWithBlob;

namespace Ngaq.Core.Shared.Sync;


public interface IPacker<T>{
	
	[Doc(@$"{nameof(ITextWithMemory)}格式 默認 GZip壓縮後之Jsonl(ndjson)。")]
	public ITextWithMemory Pack(
		IAsyncEnumerable<T> Objs, IObjPackInfo PackInfo, CT Ct
	);
	
	[Doc(@$"{nameof(ITextWithMemory)}格式 默認 GZip壓縮後之Jsonl(ndjson)。")]
	public IAnswer<IAsyncEnumerable<T>> Unpack(
		ITextWithMemory TextWithBlob, CT Ct
	);
	
	
}
