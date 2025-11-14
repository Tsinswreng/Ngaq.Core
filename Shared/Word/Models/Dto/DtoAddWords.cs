namespace Ngaq.Core.Shared.Word.Models.Dto;
using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Word.Models.Dto;



public partial class DtoSyncWords{
	/// <summary>
	/// 庫中未有之待添之諸新詞 若從文本詞表則按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<IJnWord> NeoWords{get;set;} = new List<IJnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUdpWord> UpdatedWords{get;set;} = new List<DtoUdpWord>();
}

public class DtoUdpWord{
	public IJnWord? WordInDb{get;set;}
	public DtoSyncTwoWords DtoSyncTwoWords{get;set;} = new();
}


#region Old


[Obsolete]
public partial class DtoUpdWordOld2{
	public DtoUpdWordOld2(
		IJnWord WordInDb
		,IJnWord NeoPart
		,IJnWord ChangedPart
	){
		this.WordInDb = WordInDb;
		this.NeoPart = NeoPart;
		this.ChangedPart = ChangedPart;
	}
	/// <summary>
	/// 庫中既有之詞
	/// </summary>
	public IJnWord WordInDb{get;set;}
	/// <summary>
	/// 待添之詞(NeoPart)
	/// </summary>
	public IJnWord? NeoPart{get;set;}
	/// <summary>
	/// WordToAdd有洏WordInDb無之屬性 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>

	/// <summary>
	/// WordToAdd 與 WordInDb 之差集 (ChangedPart)
	/// </summary>
	//public DtoWordDiff DtoWordDiff{get;set;}
	public IJnWord? ChangedPart{get;set;}

}

[Obsolete]
public partial class DtoSyncWordsOld2{
	/// <summary>
	/// 庫中未有之待添之諸新詞 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<IJnWord> NeoWords{get;set;} = new List<IJnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdWordOld2> UpdatedWords{get;set;} = new List<DtoUpdWordOld2>();
}





public partial class DtoUpdWordOld{
	public DtoUpdWordOld(
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

public partial class DtoAddWordsOld{
	/// <summary>
	/// 庫中未有之待添之諸新詞 按description數量決定'add'ˉLeanrnRecord之數
	/// </summary>
	public IList<IJnWord> NeoWords{get;set;} = new List<IJnWord>();
	/// <summary>
	/// 待更新之諸詞
	/// </summary>
	public IList<DtoUpdWordOld> UpdatedWords{get;set;} = new List<DtoUpdWordOld>();
}

#endregion
