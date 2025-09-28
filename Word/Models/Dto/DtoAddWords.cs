using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Word.Models;
using Ngaq.Core.Word.Models.Dto;

namespace Ngaq.Core.Model.Word.Dto;

public partial class DtoUpdWord{
	public DtoUpdWord(
		JnWord WordInDb
		,JnWord WordToAdd
		,JnWord DiffedWord
	){
		this.WordInDb = WordInDb;
		this.WordToAdd = WordToAdd;
		this.DiffedWord = DiffedWord;
	}
	/// <summary>
	/// 庫中既有之詞
	/// </summary>
	public JnWord WordInDb{get;set;}
	/// <summary>
	/// 待添之詞
	/// </summary>
	public JnWord WordToAdd{get;set;}
	/// <summary>
	/// WordToAdd有洏WordInDb無之屬性 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>

	/// <summary>
	/// WordToAdd 與 WordInDb 之差集
	/// </summary>
	//public DtoWordDiff DtoWordDiff{get;set;}
	public JnWord DiffedWord{get;set;}

}

public partial class DtoAddWords{
	/// <summary>
	/// 庫中未有之待添之諸新詞 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<JnWord> NeoWords{get;set;} = new List<JnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdWord> UpdatedWords{get;set;} = new List<DtoUpdWord>();
}

