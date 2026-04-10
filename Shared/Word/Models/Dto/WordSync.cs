using Ngaq.Core.Shared.Word.Models.Po.Word;

namespace Ngaq.Core.Shared.Word.Models.Dto;

[Doc(@$"{nameof(JnWord)}比較情況、用于同步。
設把Remote合入Local。

當{nameof(RemoteIsOlder)}==true時 忽略其他字段的值 因爲已經不需操作了。
除此之外、兩個單詞有不同時、默認Remote更加新。

合併操作 只能對Local做改動。

Remote和Local的 ({nameof(PoWord.Owner)},{nameof(PoWord.Head)},{nameof(PoWord.Lang)})須一致、
{nameof(PoWord.Id)}可能不一致。

下面的條目未必是互拆的、可能有同時滿足的項目。

名詞解釋:
- 資產(Assets)指 {nameof(JnWord.Props)} 或 {nameof(JnWord.Learns)};
- 對于單個資產、軟刪除也屬于Change
")]
public class WordDiffCaseForSync{
	[Doc(@$"兩個單詞都沒有變化。不用做。")]
	public bool NoChange{get;set;}
	[Doc(@$"Remote更舊、不需要改動Local。
	==true時 忽略其他字段的值 因爲已經不需操作了
	")]
	public bool RemoteIsOlder{get;set;}
	
	[Doc(@$"Remote 在 接收合入的一方 沒有對應的Local。
	直接把Remote入庫即可。
	")]
	public bool LocalNotExist {get;set;}
	
	[Doc(@$"
	Remote中有新增之資產 which is Local中沒有的。
	需把Local缺少的部分入庫。
	")]
	public bool RemoteHasNewAssets{get;set;}
	
	[Doc(@$"Remote和Local 資產數相同 但對應Id的資產中有的是 Remote的更加新。
	資產被軟刪除也算Change。
	需把有改變的部分在庫中對應更改。
	")]
	public bool RemoteHasChangedAssets{get;set;}
	
	[Doc(@$"Remote和Local的Id不一致、
	可能是 本來 要合併的兩個節點 根本就不存在 Remote 和 Local、
	在合併前、他們各自在不同時刻添加了 相同(Head,Lang)的單詞。
	于是會各自形成兩個 Id不同的JnWord。
	此時應取更老者的Id作最終Id。
	")]
	public bool RemoteEtLocalNotHaveSameId{get;set;}
	
	[Doc(@$"需把Local也同步軟刪除。資產若有不同也要合併。")]
	public bool RemoteIsSoftDeleted{get;set;}
	
	[Doc(@$"Local被軟刪除。需把Local的軟刪除狀態去除。")]
	public bool LocalIsSoftDeleted{get;set;}
	
	[Doc(@$"{nameof(JnWord.Word)}有變化。")]
	public bool WordCoreIsChanged{get;set;}
	
}

[Doc(@$"一對{nameof(JnWord)}同步結果。
Remote合入Local。
#See[{nameof(WordDiffCaseForSync)}]
")]
public class DtoSyncResult{
	public WordDiffCaseForSync DiffCase{get;set;} = new();
	public JnWord? Local{get;set;}
	public JnWord? Remote{get;set;}
	[Doc(@$"僅含 Remote 比 Local多出的新資產。
	不考慮其{nameof(JnWord.Word)}
	")]
	public JnWord? NewAssets{get;set;}
	[Doc(@$"僅含 Remote 比 Local 更改的資產。
	不考慮其{nameof(JnWord.Word)}
	")]
	public JnWord? ChangedAssets{get;set;}
}
