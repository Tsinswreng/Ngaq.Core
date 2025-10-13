using Ngaq.Core.Infra.IF;
using Ngaq.Core.Models.Sys.Po.User;

namespace Ngaq.Core.Models.Sys.Resp;

public  partial class RespLogin: IAppSerializable{
	public str? AccessToken{get;set;} = "";
	public str UserIdStr{get;set;} = "";
	public PoUser? PoUser{get;set;}
}
