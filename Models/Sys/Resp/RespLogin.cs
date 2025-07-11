using Ngaq.Core.Model.Sys.Po.User;

namespace Ngaq.Core.Models.Sys.Resp;

public class RespLogin{
	public str? Token{get;set;} = "";
	public PoUser? PoUser{get;set;}
}
