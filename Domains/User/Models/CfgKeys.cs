namespace Ngaq.Core.Sys.Models;

public partial class DbCfgKeys{
	/// <summary>
	/// 此詞庫ʹid
	/// </summary>
	public const str NodeId = nameof(NodeId);//str
	/// <summary>
	/// 時芝本地ʹ新進度ˇ傳至遠端
	/// </summary>
	public const str LastUploadTime = nameof(LastUploadTime);//i64
	/// <summary>
	/// 時芝遠端ʹ新進度ˇ傳至本地
	/// </summary>
	public const str LastDownloadTime = nameof(LastDownloadTime);//i64
}
