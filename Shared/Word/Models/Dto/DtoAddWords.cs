namespace Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Word.Models.Dto;



public partial class DtoUpdWord{
	public DtoUpdWord(
		IJnWord WordInDb
		,IJnWord WordToAdd
		,IJnWord DiffedWord
	){
		this.WordInDb = WordInDb;
		this.WordToAdd = WordToAdd;
		this.DiffedWord = DiffedWord;
	}
	/// <summary>
	/// 庫中既有之詞
	/// </summary>
	public IJnWord WordInDb{get;set;}
	/// <summary>
	/// 待添之詞
	/// </summary>
	public IJnWord WordToAdd{get;set;}
	/// <summary>
	/// WordToAdd有洏WordInDb無之屬性 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>

	/// <summary>
	/// WordToAdd 與 WordInDb 之差集
	/// </summary>
	//public DtoWordDiff DtoWordDiff{get;set;}
	public IJnWord DiffedWord{get;set;}

}

public partial class DtoAddWords{
	/// <summary>
	/// 庫中未有之待添之諸新詞 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<IJnWord> NeoWords{get;set;} = new List<IJnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdWord> UpdatedWords{get;set;} = new List<DtoUpdWord>();
}

