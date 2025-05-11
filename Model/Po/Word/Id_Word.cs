namespace Ngaq.Core.Model.Po.Word;

using T_Val = System.UInt128;
using T_IdStruct = Id_Word;
using System.Buffers.Binary;
using Ngaq.Core.Tools;

public struct Id_Word(T_Val v)
	:IEquatable<T_IdStruct>
{
	public T_Val Value{get;} = v;
	public Id_Word():this(0)
	{
		Value = IdTool.NewUlid_UInt128();
	}

	public bool Equals(T_IdStruct other) {
		return Value.Equals(other.Value);
	}

	public static bool operator ==(T_IdStruct left, T_IdStruct right)
		=> left.Value == right.Value;

	public static bool operator !=(T_IdStruct left, T_IdStruct right)
		=> !(left == right);

	// 重写 object.Equals
	public override bool Equals(object? obj)
		=> obj is T_IdStruct other && Equals(other);

	// 重写 GetHashCode
	public override int GetHashCode()
		=> Value.GetHashCode();

}
