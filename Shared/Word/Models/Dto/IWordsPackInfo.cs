namespace Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;


public enum EWordsPack{
	None,
/// <summary>
/// 按行分隔之獨立JnWord Json、非Json數組
/// {}
/// {}
/// {}
///
/// </summary>
	LineSepJnWordJsonGZip,
	/// <summary>
	/// Json數組
	/// </summary>
	JnWordArrJsonGZip
}


// public class StrEnumWordsPack{
// 	[DoNotRename("Persistence")]
// 	public const str LineSepJnWordJsonGZip = nameof(LineSepJnWordJsonGZip);

// 	[DoNotRename("Persistence")]
// 	public const str JnWordArrJsonGZip = nameof(JnWordArrJsonGZip);
// }



public interface IWordsPackInfo
	:IAppSerializable
	,I_VerApp
{
	public static Version ClassVer = new Version(1,0,0);
	[EnumOf(typeof(EWordsPack))]
	public EWordsPack Type{get;set;}
	public Tempus CreatedAt{get;set;}
	/// <summary>
	/// DTO版本
	/// </summary>
	public Version? Ver{get;set;}
	#if Impl
	= IWordsPackInfo.ClassVer;
	#endif
	/// <summary>
	/// 應用程式版本
	/// 雖請求頭會自動帶AppVer、肰WordsPack亦有本地導出之況
	/// </summary>
	//public Version? VerApp{get;set;}

	/// <summary>
	/// JnWord聚合根版本
	/// </summary>
	public Version? VerJnWord{get;set;}


}
