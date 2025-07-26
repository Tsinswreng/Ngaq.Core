using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Sys.Po.Password;


public  partial class PoPassword
	:PoBase
	,I_Id<IdPassword>
{
	public IdPassword Id{get;set;}
	public i64 Algo{get;set;}
	public str Text{get;set;}="";
	/// <summary>
	/// 蜮直ᵈ被含于Text中 如用Argon2id旹 此旹不用管 鹽
	/// </summary>
	public str Salt{get;set;} ="";

	public IdUser UserId{get;set;}
	public enum EAlgo{
		Argon2id = 1,
	}

}
