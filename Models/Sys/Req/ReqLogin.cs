using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Models.Sys.Req{
public partial class ReqLogin: IAppSerializable{
	public str? UniqueName{get;set;}
	public str? Email{get;set;}
	public str? Password{get;set;}
	public i32 UserIdentityMode{get;set;} = (i32)EUserIdentityMode.UniqueName;
	public bool KeepLogin{get;set;} = false;

	public enum EUserIdentityMode{
		UniqueName = 1,
		Email = 2
	}
}

}//~Ns



