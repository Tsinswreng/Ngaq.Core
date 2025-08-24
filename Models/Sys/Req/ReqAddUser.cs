using Ngaq.Core.Infra.IF;

namespace Ngaq.Core.Model.Sys.Req;

public  partial class ReqAddUser: IAppSerializable{
	public str? UniqueName{get;set;} = "";
	public str Email{get;set;} = "";
	public str Password{get;set;} = "";
}
