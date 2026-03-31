using Ngaq.Core.Frontend.User;
using Ngaq.Core.Shared.User.UserCtx;
using Tsinswreng.CsSql;

namespace Ngaq.Core.Infra;

[Doc(@$"Service context, mostly used in the first param of service API methods")]
public interface IDbUserCtx{
	public IDbFnCtx? DbFnCtx{get;set;}
	public IUserCtx UserCtx{get;set;}
}

public class DbUserCtx : IDbUserCtx{
	public DbUserCtx(IUserCtx UserCtx, IDbFnCtx? DbFnCtx = null){
		this.DbFnCtx = DbFnCtx;
		this.UserCtx = UserCtx;
	}
	public IDbFnCtx? DbFnCtx{get;set;}
	public IUserCtx UserCtx{get;set;}
}

public static class ExtnIDbUserCtx{
	extension(IUserCtx z){
		public IDbUserCtx ToDbUserCtx(IDbFnCtx? DbFnCtx = null){
			return new DbUserCtx(z, DbFnCtx);
		}
	}
	extension(IFrontendUserCtxMgr z){
		public IDbUserCtx GetDbUserCtx(IDbFnCtx? DbFnCtx = null){
			return new DbUserCtx(z.GetUserCtx());
		}
	}
}
