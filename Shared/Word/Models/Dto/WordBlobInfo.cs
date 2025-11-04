namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra;
using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;

public enum EWordsPack{
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

public interface IWordsPackInfo:IAppSerializable{
	public EWordsPack Type{get;set;}
	public Tempus CreatedAt{get;set;}
}

public class WordsPackInfo:IWordsPackInfo,IAppSerializable{
	public EWordsPack Type{get;set;}
	public Tempus CreatedAt{get;set;} = Tempus.Now();
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
