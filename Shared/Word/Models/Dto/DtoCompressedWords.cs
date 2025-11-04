namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;


public class DtoCompressedWords
	:IWordsPackInfo
	,IAppSerializable
{
	public u8[]? Data{get;set;}
	public EWordsPack Type{get;set;}
	public Tempus CreatedAt{get;set;} = Tempus.Now();
}

public static class ExtnDtoCompressedWords{
	public static IWordsPackInfo ToOrAssWordsPackInfo(this DtoCompressedWords z){
		return z;
	}
}
