namespace Ngaq.Core.Models.Po;

using TStruct = PoStatus;
using TPrimitive = i32;
using System.Diagnostics.CodeAnalysis;

public struct PoStatus(TPrimitive V)
	:IEquatable<PoStatus>
{
	public static PoStatus Parse(TPrimitive v){
		return new PoStatus(v);
	}

	public static PoStatus Normal = new PoStatus(0);
	public static PoStatus Deleted = new PoStatus(1);
	public static PoStatus Disabled = new PoStatus(2);

	public TPrimitive Value{get;set;} = V;

	public static implicit operator TPrimitive(TStruct e){
		return e.Value;
	}
	public static implicit operator TStruct(TPrimitive s){
		return new TStruct(s);
	}

	public override bool Equals([NotNullWhen(true)] object? obj) {
		return obj is TStruct learn && Value.Equals(learn.Value);
	}

	public bool Equals(TStruct other) {
		return Value.Equals(other.Value);
	}

	public static bool operator ==(TStruct left, TStruct right) {
		return left.Equals(right);
	}

	public static bool operator !=(TStruct left, TStruct right) {
		return left.Equals(right);
	}

	public static bool operator >(TStruct left, TStruct right) {
		return left.Value > right.Value;
	}

	public static bool operator <(TStruct left, TStruct right) {
		return left.Value > right.Value;
	}

	public override int GetHashCode() {
		return Value.GetHashCode();
	}

}

