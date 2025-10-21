#define Impl
namespace Ngaq.Core.Domains.Word.Models.Po.Kv;

using Ngaq.Core.Domains.Base.Models.Po;
using Ngaq.Core.Infra;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Po.Word;


//TODO 分組㕥辨一詞多義? group, groupId, groupCnt
public partial class PoWordProp
	:PoBase
	,I_Id<IdWordProp>
	,IPoKv
	,I_WordId
	,IBizCreateUpdateTime
{
	public IdWordProp Id { get; set; } = new IdWordProp();

	public IdWord WordId{get;set;}

	public EKvType KType { get; set; } = EKvType.Str;
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	public i64 KI64 { get; set; }
	//public str KeyType {get; set;} = "";


	public EKvType VType { get; set; }

	public str? VStr { get; set; }

	public i64 VI64 { get; set; }

	public f64 VF64 { get; set; }
	#region IBizCreateUpdateTime
	/// <summary>
	/// 理則ₐ實體ˇ增ʹ時、如于單詞、則始記于文本單詞表中之時 即其CreatedAt、非 存入數據庫之時
	/// 潙null旹示與InsertedBy同。亦可早於InsertedAt。
	/// </summary>
	public Tempus CreatedAt{get;set;}
	#if Impl
		= new();
	#endif
	/// <summary>
	/// 理則ₐ實體ˇ改ʹ時
	/// 如ʃ有ʹ子實體ˋ變˪、則亦宜改主實體或聚合根ʹUpdatedAt
	/// </summary>
	public Tempus UpdatedAt{get;set;}
	#if Impl
		= Tempus.Zero;
	#endif

	#endregion IBizCreateUpdateTime

}
