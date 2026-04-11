using Ngaq.Core.Shared.Word.Models.Po.Word;

namespace Ngaq.Core.Shared.Word.Models.Dto;

[Doc(@$"用于兩持久對象同步。
按業務層唯一標識(BizId)比較、而不是按數據庫中生成的Id。
")]
public enum EDiffByBizIdResultForSync{
	[Doc(@$"兩個對象都沒有變化。不用做。")]
	NoChange,
	
	[Doc(@$"常見情況")]
	RemoteIsNewer,
	
	[Doc(@$"Remote更舊、不需要改動Local。
	==true時 忽略其他字段的值 因爲已經不需操作了
	")]
	RemoteIsOlder,
	
	[Doc(@$"Remote 在 接收合入的一方 沒有對應的Local。
	直接把Remote入庫即可。
	")]
	LocalNotExist,
	
	[Doc(@$"
	Remote和Local的Id不一致、
	可能是 本來 要合併的兩個節點 根本就不存在 Remote 和 Local、
	在合併前、他們各自在不同時刻添加了 相同BizId的實體。
	于是會各自形成兩個 Id不同的對象。
	此時 理論上Local和Remote不會有重合的資產。
	Local的資產需接收Remote的資產的合入(不會)。下次Remote再從Local合入其兩端資產即可同步。
	
	假如場景爲 {nameof(JnWord)}的同步、則
	Local的{nameof(JnWord.Word)}改爲
	Local和Remote中{nameof(PoWord.BizCreatedAt)}最小者的PoWord
	")]
	
	IdNotEqual,
}

[Doc(@$"
適用于當{nameof(EDiffByBizIdResultForSync.RemoteIsNewer)}時。
聚合類的比較情況、用于同步。
設把Remote合入Local。

兩個聚合類有不同時、默認Remote更加新。

合併操作 只能對Local做改動。

Remote和Local的BizId(業務層唯一標識、非Id字段)須一致、
Id可能不一致。

下面的條目未必是互斥的、可能有同時滿足的項目。

名詞解釋:
- 資產(Assets): 指聚合對象中 除了聚合根之外的實體(或實體列表)
	例:對于{nameof(JnWord)}而言、其資產即 {nameof(JnWord.Props)} 和 {nameof(JnWord.Learns)};
- 對于單個資產、軟刪除也屬于Change。

比較一對資產實體時是按Id比較。資產實體可能沒有BizId。
")]
public class AggDiffCaseForSync{
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
	
	[Doc(@$"需把Local也同步軟刪除。資產若有不同也要合併。")]
	public bool RemoteIsSoftDeleted{get;set;}
	
	[Doc(@$"Local被軟刪除。需把Local的軟刪除狀態去除。")]
	public bool LocalIsSoftDeleted{get;set;}
	
	[Doc(@$"聚合根有變化。
	對 {nameof(JnWord)}而言、 其聚合根即 {nameof(JnWord.Word)}
	")]
	public bool AggRootIsChanged{get;set;}
	
}


[Doc(@$"一對聚合實體(也可能是單個Po)同步結果。
Remote合入Local。
#See[{nameof(AggDiffCaseForSync)}]
")]
public interface IAggSyncResult<T>{
	public EDiffByBizIdResultForSync DiffResult{get;set;}
	
	[Doc(@$"適用于當{nameof(EDiffByBizIdResultForSync.RemoteIsNewer)}時。")]
	public AggDiffCaseForSync? DiffCase{get;set;}
	
	[Doc(@$"同步前的Local 原對象")]
	public T? Local{get;set;}
	[Doc(@$"Remote對象")]
	public T? Remote{get;set;}
	
	[Doc(@$"僅含 Remote 比 Local多出的新資產。
	不考慮此字段之聚合根
	#Example([
	假設{nameof(T)}是{nameof(JnWord)}、
	則此字段爲多出的{nameof(JnWord.Props)}和{nameof(JnWord.Learns)}、
	不要管這個字段的{nameof(JnWord.Word)}(聚合根)
	])
	")]
	public T? NewAssets{get;set;}
	
	[Doc(@$"僅含 Remote 比 Local 更改的資產。
	不考慮此字段之聚合根
	#See[{nameof(NewAssets)}]
	")]
	public T? ChangedAssets{get;set;}
	
	[Doc(@$"同步後的聚合根。
	用來對應更新Local的聚合根。
	")]
	public T? SyncedPoWord{get;set;}
}

[Doc(@$"一對{nameof(JnWord)}同步結果。
Remote合入Local。
#See[{nameof(AggDiffCaseForSync)}]
")]
public class DtoJnWordSyncResult{
	public EDiffByBizIdResultForSync DiffResult{get;set;}
	
	[Doc(@$"適用于當{nameof(EDiffByBizIdResultForSync.RemoteIsNewer)}時。")]
	public AggDiffCaseForSync? DiffCase{get;set;}
	
	[Doc(@$"同步前的Local 原詞")]
	public JnWord? Local{get;set;}
	[Doc(@$"Remote原詞")]
	public JnWord? Remote{get;set;}
	
	[Doc(@$"僅含 Remote 比 Local多出的新資產。
	不考慮其{nameof(JnWord.Word)}
	")]
	public JnWord? NewAssets{get;set;}
	[Doc(@$"僅含 Remote 比 Local 更改的資產。
	不考慮其{nameof(JnWord.Word)}
	")]
	public JnWord? ChangedAssets{get;set;}
	
	[Doc(@$"同步後的{nameof(JnWord.Word)}。
	用來對應更新Local的PoWord。
	")]
	public PoWord? SyncedPoWord{get;set;}
}


[Doc(@$"比較單個實體。
用于同步。
設把Remote合入Local。
")]
public class DtoEntityDiffEtSync<T>{
	[Doc(@$"
	0:一樣新;
	正數:Local更加新;
	負數:Remote更加新
	")]
	public i32 LocalCompareToRemote{get;set;}
	[Doc(@$"同步後的實體")]
	public T? SyncedEntity{get;set;}
}


[Doc(@$"兩 {nameof(PoWord)} 按時間比較")]
public enum EPoWordCompare{
	[Doc(@$"{nameof(PoWord.BizCreatedAt)}, {nameof(PoWord.BizUpdatedAt)}")]
	Equal,
}
