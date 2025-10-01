namespace Ngaq.Core.Model.Sys.Po;

using Ngaq.Core.Model.Consts;
using StronglyTypedIds;

/// <summary>
/// 軟刪除標記 blobʹ ULID
/// 不用時間戳蔿防撞ⁿ觸唯一約束
/// </summary>
[StronglyTypedId(ConstStrongTypeIdTemplate.UInt128)]
public partial struct IdDel {

}
