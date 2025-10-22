namespace Ngaq.Core.Shared.User.Models.Po.User;

using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;


public partial class PoUser
	:PoBaseBizTime
	,I_Id<IdUser>
{
	public IdUser Id{get;set;} = new();
	public str UniqueName{get;set;} = "";
	public str? NickName{get;set;}
	public str Email{get;set;} = "";
	public str? PhoneNumber{get;set;}
	public str? Avatar{get;set;}
	//public IdRole RoleId{get;set;}
	//public IEnumerable<Id_Password> PasswordIds{get;set;}=[]; //AI曰不要此
	//public ICollection<Model_Password> Passwords{get;set;}=[]; //取消導航屬性 只在關聯實體類中留外鍵 降侵入性

	public class N{
		public str Id = nameof(PoUser.Id);
		public str UniqueName = nameof(PoUser.UniqueName);
		public str NickName = nameof(PoUser.NickName);
		public str Email = nameof(PoUser.Email);
		public str PhoneNumber = nameof(PoUser.PhoneNumber);
		public str Avatar = nameof(PoUser.Avatar);
	}

}

