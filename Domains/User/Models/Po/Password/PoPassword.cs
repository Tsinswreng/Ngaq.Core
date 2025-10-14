namespace Ngaq.Core.Models.Sys.Po.Password;

using Ngaq.Core.Domains.User.Models.Po.User;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Sys.Po.Password;
using Ngaq.Core.Models.Po;


public partial class PoPassword
	:PoBase
	,I_Id<IdPassword>
{
	public IdPassword Id{get;set;}
	public IdUser UserId{get;set;}
	public EAlgo Algo{get;set;} = EAlgo.Argon2id;
	public str Text{get;set;}="";
	/// <summary>
	/// 蜮直ᵈ被含于Text中 如用Argon2id旹 此旹不用管 鹽
	/// </summary>
	//public str? Salt{get;set;} =""; 使Text含Salt。具體格式決于Algo
	public enum EAlgo{
		Argon2id = 1,
	}

}
