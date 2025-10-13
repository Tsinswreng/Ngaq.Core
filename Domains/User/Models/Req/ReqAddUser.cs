namespace Ngaq.Core.Domains.User.Models.Req;

using Ngaq.Core.Domains.Base.Models.Req;

public partial class ReqAddUser: IReq{
	public str? UniqueName{get;set;} = "";
	public str Email{get;set;} = "";
	public str Password{get;set;} = "";
}
