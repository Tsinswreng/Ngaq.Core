using System.Text;
using Ngaq.Core.Model;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Stream;
using Ngaq.Core.Tools.Io;

namespace Ngaq.Core.Service.Word;

/// <summary>
/// 從 路經/字串/字節生產者 解析單詞表文本、得Bo_Word列表。
/// </summary>
public interface I_Svc_ParseWordList{

	// Task<I_Answer<IList<Bo_Word>>> ParseWordsByIterEtEncoding(
	// 	I_I
	// );

	Task<IEnumerable<Bo_Word>> ParseWordsFromFilePathAsy(
		Path_Encode Path_Encode
		,CancellationToken ct = default
	);

	Task<IEnumerable<Bo_Word>> ParseWordsFromUrlAsy(
		str Path
		,CancellationToken ct = default
	);

	Task<IEnumerable<Bo_Word>> ParseWordsFromTextAsy(
		str Text
		,CancellationToken ct = default
	);

	Task<IEnumerable<Bo_Word>> ParseWordsByIterEtEncodingAsy(
		I_Iter<u8> Iter
		,Encoding Encoding
		,CancellationToken ct = default
	);

}
