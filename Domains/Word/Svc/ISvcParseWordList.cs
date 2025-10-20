using System.Text;
using Ngaq.Core.Domains.Word.Models;
using Ngaq.Core.Model;
using Ngaq.Core.Stream;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;

/// <summary>
/// 從 路經/字串/字節生產者 解析單詞表文本、得Bo_Word列表。
/// </summary>
public  partial interface ISvcParseWordList{

	// Task<I_Answer<IList<Bo_Word>>> ParseWordsByIterEtEncoding(
	// 	I_I
	// );

	Task<IEnumerable<JnWord>> ParseWordsFromFilePath(
		Path_Encode Path_Encode
		,CancellationToken ct = default
	);

	Task<IEnumerable<JnWord>> ParseWordsFromUrlAsy(
		str Path
		,CancellationToken ct = default
	);

	Task<IEnumerable<JnWord>> ParseWordsFromText(
		str Text
		,CancellationToken ct = default
	);

	Task<IEnumerable<JnWord>> ParseWordsByIterEtEncodingAsy(
		IIter<u8> Iter
		,Encoding Encoding
		,CancellationToken ct = default
	);

}
