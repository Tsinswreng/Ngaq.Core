using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Shared.Dictionary.Models;
using Ngaq.Core.Shared.User.Models.Po.User;
using Ngaq.Core.Shared.Word.Models.Po.Word;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Shared.Word.Models.Po.UserLang;

[Doc(@$"
此實體中定義 用戶自定義的語言(即 {nameof(PoWord.Lang)})
與 標準化的語言標識 的關聯。 用于查字典。
")]
public partial class PoUserLang
	:PoBaseBizTime
	,I_Id<IdUserLang>
	,I_Owner
	,I_UniqName
{
	public IdUserLang Id { get; set; } = new();
	public IdUser Owner { get; set; }
	[Doc("用戶自定義的語言 唯一名 (Owner, UniqName)唯一")]
	public str? UniqName {get;set;} = "";
	public str? Descr {get;set;} = "";
	
	[Doc(@$"關聯的 標準化的 語言標識 類型 如 {nameof(ELangIdentType.Bcp47)}")]
	public ELangIdentType RelLangType{get;set;} = ELangIdentType.Bcp47;
	
	[Doc(@$"關聯的 標準化的 語言標識
	如 當使用 {nameof(ELangIdentType.Bcp47)}時的 `zh-Hant-TW`")]
	public str RelLang{get;set;} = "";
	
	
	
	
}
