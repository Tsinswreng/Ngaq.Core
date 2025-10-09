#define Impl
namespace Ngaq.Core.Models.Sys.Po.Role;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Role;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;



public partial class PoRole
	:PoBase
	,I_Id<IdRole>
{
	public IdRole Id { get; set; }
	/// <summary>
	/// 全局唯一標識 如ADMIN
	/// </summary>
	public str Key {get;set;} = "";

	public str Name{get;set;} = "";

}
