using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Models.Sys.Resp;

public class RespLogin{
	public str? AccessToken{get;set;} = "";
	public str UserIdStr{get;set;} = "";
	public PoUser? PoUser{get;set;}
}
