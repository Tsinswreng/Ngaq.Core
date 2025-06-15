using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Model.Word.Dto;

public class DtoUpdatedWord{
	public DtoUpdatedWord(
		JnWord WordInDb
		,JnWord WordToAdd
		,IList<PoWordProp> DiffedProps
	){
		this.WordInDb = WordInDb;
		this.WordToAdd = WordToAdd;
		this.DiffedProps = DiffedProps;
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
	public IList<PoWordProp> DiffedProps{get;set;} = new List<PoWordProp>();

}

public class DtoAddWords{
	/// <summary>
	/// 庫中未有之待添之諸新詞 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<JnWord> NeoWords{get;set;} = new List<JnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdatedWord> UpdatedWords{get;set;} = new List<DtoUpdatedWord>();
}
