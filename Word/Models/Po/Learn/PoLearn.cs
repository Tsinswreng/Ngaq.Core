#define Impl
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Learn_;

namespace Ngaq.Core.Model.Po.Learn_;

// public class Po_Learn:Po_Kv{
// 	public static new Po_Learn Example{get;set;} = new Po_Learn();
// }


public partial class PoWordLearn
	:PoBase
	,I_Id<IdLearn>
	,I_WordId
	//,IPoKv
{

	public static PoWordLearn Example{get;set;} = new PoWordLearn();

	public IdLearn Id { get; set; } = new IdLearn();

	public IdWord WordId{get;set;}

	public str LearnResult{get;set;}="";
}
