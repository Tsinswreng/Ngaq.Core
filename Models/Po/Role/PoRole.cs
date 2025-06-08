#define Impl
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Po.Role;

public class PoRole
	:PoBase
	,I_Id<IdRole>
{
	public IdRole Id { get; set; }
	public str? Key {get;set;}

}
