using Ngaq.Core.Shared.User.UserCtx;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Infra;

[Doc(@$"Service context, mostly used in the first param of service API methods")]
public interface IDbUserCtx{
	public IDbFnCtx? DbFnCtx{get;set;}
	public IUserCtx UserCtx{get;set;}
}

public class DbUserCtx : IDbUserCtx{
	public DbUserCtx(IDbFnCtx? DbFnCtx, IUserCtx UserCtx){
		this.DbFnCtx = DbFnCtx;
		this.UserCtx = UserCtx;
	}
	public IDbFnCtx? DbFnCtx{get;set;}
	public IUserCtx UserCtx{get;set;}
}
