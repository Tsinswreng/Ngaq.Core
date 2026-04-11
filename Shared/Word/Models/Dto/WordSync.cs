using Ngaq.Core.Shared.Word.Models.Po.Word;

namespace Ngaq.Core.Shared.Word.Models.Dto;






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



