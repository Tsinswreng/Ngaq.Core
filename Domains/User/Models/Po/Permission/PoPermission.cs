using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Model.Po;

namespace Ngaq.Core.Models.Sys.Po.Permission;


public class PoPermission
	:PoBase
	,I_Id<IdPermission>
{
	public IdPermission Id{get;set;}
	public str Code{get;set;} = "";
	public str Name{get;set;} = "";
	public str? Descr{get;set;} = "";

}
