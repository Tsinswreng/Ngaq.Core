namespace Ngaq.Core.Domains.User.Models.Po.User;

using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Models.Po;


public partial class PoUser
	:PoBase
	,I_Id<IdUser>
	,IBizCreateUpdateTime
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
	#region IBizCreateUpdateTime
	/// <summary>
	/// 理則ₐ實體ˇ增ʹ時、如于單詞、則始記于文本單詞表中之時 即其CreatedAt、非 存入數據庫之時
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus BizCreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	/// <summary>
	/// 理則ₐ實體ˇ改ʹ時
	/// 如ʃ有ʹ子實體ˋ變˪、則亦宜改主實體或聚合根ʹUpdatedAt
	/// </summary>
	public Tempus BizUpdatedAt{get;set;}
	#if Impl
		= Tempus.Zero;
	#endif

	#endregion IBizCreateUpdateTime

	public class N{
		public str Id = nameof(PoUser.Id);
		public str UniqueName = nameof(PoUser.UniqueName);
		public str NickName = nameof(PoUser.NickName);
		public str Email = nameof(PoUser.Email);
		public str PhoneNumber = nameof(PoUser.PhoneNumber);
		public str Avatar = nameof(PoUser.Avatar);
	}

}

