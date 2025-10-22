namespace Ngaq.Core.Shared.User.Models.Po.User;

using Ngaq.Core.Model.Consts;
using StronglyTypedIds;

[StronglyTypedId(ConstStrongTypeIdTemplate.UInt128)]
public partial struct IdUser {
	public static IdUser Zero = default;
}
