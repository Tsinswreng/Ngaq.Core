namespace Ngaq.Core.Model.Sys.Req;

public class ReqLogin{
	public str? UniqueName{get;set;}
	public str? Email{get;set;}
	public str? Password{get;set;}
	public i64 UserIdentityMode{get;set;} = (i64)EUserIdentityMode.UniqueName;
	public bool KeepLogin{get;set;} = false;

	public enum EUserIdentityMode{
		UniqueName = 1,
		Email = 2
	}
}
