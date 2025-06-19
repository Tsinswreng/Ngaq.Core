#define Impl
using Tsinswreng.CsCore;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Learn_;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Word.Models.Po.Learn;

// public class Po_Learn:Po_Kv{
// 	public static new Po_Learn Example{get;set;} = new Po_Learn();
// }

/// <summary>
/// 不當改其CreatedAt與UpdatedAt。唯可刪實體
/// </summary>
public partial class PoWordLearn
	:PoBase
	,IPoBase
	,I_Id<IdLearn>
	,I_WordId
	//,IPoKv
{

	public static PoWordLearn Example{get;set;} = new PoWordLearn();

	public IdLearn Id { get; set; } = new IdLearn();

	public IdWord WordId{get;set;}

	public str LearnResult{get;set;}="";


}
