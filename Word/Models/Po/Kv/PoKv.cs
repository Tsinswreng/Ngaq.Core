#define Impl
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Model.Sys.Po.User;
using Ngaq.Core.Models.Po;

namespace Ngaq.Core.Model.Po.Kv;
//TODO 分組㕥辨一詞多義? group, groupId, groupCnt
public partial class PoWordProp
	:PoBase
	,I_Id<IdWordProp>
	,IPoKv
	,I_WordId
{

	public static PoWordProp Example{get;set;} = new PoWordProp();

	public IdWordProp Id { get; set; } = new IdWordProp();

	// [Obsolete("用WordId")]
	// public i64 FKeyType { get; set; } = (i64)EFKeyType.UInt128;
	// [Obsolete("用WordId")]
	// public str? FKeyStr{get;set;}
	// [Obsolete("用WordId")]
	// public UInt128? FKeyUInt128{
	// 	get{return WordId.Value;}
	// 	set{throw new NotImplementedException();}
	// }
	public IdWord WordId{get;set;}

	public i64 KType { get; set; } = (i64)EKvType.Str;
	public str? KStr { get; set; }
	/// <summary>
	/// KType非I64旹、忽略KI64。用匪空類型可免裝箱
	/// </summary>
	public i64 KI64 { get; set; }
	//public str KeyType {get; set;} = "";

	public str? KDescr { get; set; }

	public i64 VType { get; set; }

	public str? VDescr { get; set; }

	//[Column("str")]
	public str? VStr { get; set; }
	//[Column("int")]
	public i64 VI64 { get; set; }

	public f64 VF64 { get; set; }
}
