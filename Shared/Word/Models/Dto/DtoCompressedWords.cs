namespace Ngaq.Core.Shared.Word.Models.Dto;

using Ngaq.Core.Infra.IF;
using Ngaq.Core.Tools;
public class DtoCompressedWords:IAppSerializable{
	public u8[]? Data;
	public ECompress Type;
}
