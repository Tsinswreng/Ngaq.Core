namespace Ngaq.Core.Models.Po;

using TStruct = PoStatus;
using TPrimitive = i32;
using System.Diagnostics.CodeAnalysis;

// public  enum PoStatus{
// 	Normal = 0,
// 	Deleted = 1,
// 	Disabled = 2
// }

#if true
public partial struct PoStatus(TPrimitive V)
	:IEquatable<PoStatus>
	,I_Value<TPrimitive>
	,I_ToSerialized
	,I_ToDeSerialized
{
	object? I_ToSerialized.ToSerialized(object? Obj) {
		if(Obj is TStruct s){
			return s.Value;
		}
		return Obj;
	}

	object? I_ToDeSerialized.ToDeSerialized(object? Obj) {
		if(Obj is TPrimitive p){
			return new TStruct(p);
		}
		return Obj;
	}

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


#endif
