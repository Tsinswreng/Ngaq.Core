using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Model.Sys.Resp;

public class RespLogin{
	public str Token{get;set;} = "";
	public PoUser PoUser{get;set;}
}
