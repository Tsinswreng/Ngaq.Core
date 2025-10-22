#define Impl
namespace Ngaq.Core.Models.Sys.Po.Role;

using Ngaq.Core.Shared.Base.Models.Po;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Role;



public partial class PoRole
	:PoBase
	,I_Id<IdRole>
{

	public enum ERoleStatus{
		Normal = 0
	}

	public IdRole Id { get; set; }
	/// <summary>
	/// 全局唯一標識 如ADMIN
	/// </summary>
	public str Code {get;set;} = "";

	public str Name{get;set;} = "";

	public ERoleStatus Status{get;set;} = ERoleStatus.Normal;

}
