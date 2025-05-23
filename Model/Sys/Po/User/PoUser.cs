using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Role;

namespace Ngaq.Core.Model.Sys.Po.User;
public partial class PoUser
	:IHasId<IdUser>
	,IPoBase
{
	public IdUser Id{get;set;}
	#region IPoBase
	public i64 CreatedAt{get;set;}
	#if Impl
		= DateTimeOffset.Now.ToUnixTimeMilliseconds();
	#endif
	public IdUser? CreatedBy{get;set;}
	public i64? UpdatedAt{get;set;}
	public IdUser? LastUpdatedBy{get;set;}//LastUpdatedBy
	public i64 Status{get;set;}
	#endregion IPoBase
	public str UniqueName{get;set;} = "";
	public str? NickName{get;set;}
	public str Email{get;set;} = "";
	public str? PhoneNumber{get;set;}
	public str? Avatar{get;set;}

	public IdRole? RoleId{get;set;}
	//public IEnumerable<Id_Password> PasswordIds{get;set;}=[]; //AI曰不要此
	//public ICollection<Model_Password> Passwords{get;set;}=[]; //取消導航屬性 只在關聯實體類中留外鍵 降侵入性
}

