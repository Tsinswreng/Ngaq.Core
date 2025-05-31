using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Kv;

namespace Ngaq.Core.Model.Word.Dto;

public class DtoUpdatedWord{
	public DtoUpdatedWord(
		BoWord WordInDb
		,BoWord WordToAdd
		,IList<PoKv> DiffedProps
	){
		this.WordInDb = WordInDb;
		this.WordToAdd = WordToAdd;
		this.DiffedProps = DiffedProps;
	}
	/// <summary>
	/// 庫中既有之詞
	/// </summary>
	public BoWord WordInDb{get;set;}
	/// <summary>
	/// 待添之詞
	/// </summary>
	public BoWord WordToAdd{get;set;}
	/// <summary>
	/// WordToAdd有洏WordInDb無之屬性
	/// </summary>
	public IList<PoKv> DiffedProps{get;set;} = new List<PoKv>();

}

public class DtoAddWords{
	/// <summary>
	/// 庫中未有之待添之諸新詞
	/// </summary>
	public IList<BoWord> NeoWords{get;set;} = new List<BoWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdatedWord> UpdatedWords{get;set;} = new List<DtoUpdatedWord>();
}
