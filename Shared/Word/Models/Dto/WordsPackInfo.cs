namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;



public class WordsPackInfo
	:IWordsPackInfo
	,IAppSerializable
{
	[EnumOf(typeof(EWordsPack))]

	public EWordsPack Type{get;set;}
	public Tempus CreatedAt{get;set;} = Tempus.Now();
	public Version? Ver{get;set;} = IWordsPackInfo.ClassVer;
	public Version? VerJnWord{get;set;} = JnWord.ClassVer;
	public Version? VerApp{get;set;} = AppVer.Inst.Ver;
}

public static class ExtnWordsPackInfo{

	public static DtoCompressedWords ToDtoCompressedWords(
		this WordsPackInfo z
		,u8[] Bytes
	){
		var R = new DtoCompressedWords();
		R.Type = z.Type;
		R.Data = Bytes;
		return R;
	}
}
