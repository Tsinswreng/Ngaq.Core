using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Role;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Models.Sys.Po.User;
public partial class PoUser
	:PoBase
	,I_Id<IdUser>
{
	public IdUser Id{get;set;} = new();
	public str UniqueName{get;set;} = "";
	public str? NickName{get;set;}
	public str Email{get;set;} = "";
	public str? PhoneNumber{get;set;}
	public str? Avatar{get;set;}
	public IdRole? RoleId{get;set;}
	//public IEnumerable<Id_Password> PasswordIds{get;set;}=[]; //AI曰不要此
	//public ICollection<Model_Password> Passwords{get;set;}=[]; //取消導航屬性 只在關聯實體類中留外鍵 降侵入性
}

