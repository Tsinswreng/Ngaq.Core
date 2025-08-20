namespace Ngaq.Core.Model.Sys.Po.User;

using Ngaq.Core.Model.Consts;
using StronglyTypedIds;

[StronglyTypedId(ConstStrongTypeIdTemplate.UInt128)]
public partial struct IdUser {

}

// #if false
// using T_Val = System.UInt128;

// //namespace Ngaq.Core.Model.Po.User;
// using T_IdStruct = Id_User;
// using System.Buffers.Binary;
// using Ngaq.Core.Tools;

// public  partial struct Id_User(T_Val v)
// 	:IEquatable<T_IdStruct>
// {
// 	public T_Val Value{get;} = v;
// 	public Id_User():this(0)
// 	{
// 		Value = IdTool.NewUlid_UInt128();
// 	}

// 	public bool Equals(T_IdStruct other) {
// 		return Value.Equals(other.Value);
// 	}

// 	public static bool operator ==(T_IdStruct left, T_IdStruct right)
// 		=> left.Value == right.Value;

// 	public static bool operator !=(T_IdStruct left, T_IdStruct right)
// 		=> !(left == right);

// 	// 重写 object.Equals
// 	public override bool Equals(object? obj)
// 		=> obj is T_IdStruct other && Equals(other);

// 	// 重写 GetHashCode
// 	public override int GetHashCode()
// 		=> Value.GetHashCode();

// }

// #endif
