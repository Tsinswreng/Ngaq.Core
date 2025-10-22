namespace Ngaq.Core.Shared.Base.Models.Req;

using Ngaq.Core.Infra.IF;


public interface IReq:IAppSerializable{
	public nil Validate(){
		return NIL;
	}

}

public static class ExtnIReq{
	public static nil Validate(this IReq req){
		return req.Validate();
	}
}
