namespace Ngaq.Core.Domains.User.Models;

public partial class KeysClientKv{
	/// <summary>
	/// 此詞庫ʹid
	/// </summary>
	public const str DeviceId = nameof(DeviceId);//64進制 Ulid
	/// <summary>
	/// 時芝本地ʹ新進度ˇ傳至遠端
	/// </summary>
	public const str LastUploadTime = nameof(LastUploadTime);//i64
	/// <summary>
	/// 時芝遠端ʹ新進度ˇ傳至本地
	/// </summary>
	public const str LastDownloadTime = nameof(LastDownloadTime);//i64
}
