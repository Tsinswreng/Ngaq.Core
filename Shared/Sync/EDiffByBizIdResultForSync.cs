using Ngaq.Core.Shared.Word.Models;
using Ngaq.Core.Shared.Word.Models.Po.Word;

namespace Ngaq.Core.Shared.Sync;
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