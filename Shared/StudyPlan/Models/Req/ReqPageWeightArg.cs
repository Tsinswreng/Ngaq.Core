using Ngaq.Core.Shared.User.Models.Po.User;
using Tsinswreng.CsPage;

namespace Ngaq.Core.Shared.StudyPlan.Models.Req;
public class ReqPageWeightArg{
	public IdUser Owner{get;set;}
	public IPageQry PageQry{get;set;}
	public str? UniqNameSearch{get;set;} = null;
}
