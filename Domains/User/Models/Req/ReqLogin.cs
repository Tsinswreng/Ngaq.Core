using Ngaq.Core.Domains.User.Models.Bo.Device;
using Ngaq.Core.Domains.User.Models.Po.Device;
using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Domains.User.Models.Req {
public partial class ReqLogin: IAppSerializable{
	public str? UniqueName{get;set;}
	public str? Email{get;set;}
	public str? Password{get;set;}
	public EUserIdentityMode UserIdentityMode{get;set;} = EUserIdentityMode.UniqueName;
	public bool KeepLogin{get;set;} = false;
	public IdClient? DeviceId{get;set;}
	public EClientType DeviceType{get;set;}
	public str? IpAddr{get;set;}

	public enum EUserIdentityMode{
		UniqueName = 1,
		Email = 2
	}
	public nil CheckSelf(){
		var z = this;
		var R = new List<str>();
		if(z.UserIdentityMode == EUserIdentityMode.UniqueName){
			if(str.IsNullOrEmpty(z.UniqueName)){

			}
		}
		return NIL;
	}
}

}//~Ns



