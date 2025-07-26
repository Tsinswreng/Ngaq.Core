using System.Diagnostics.CodeAnalysis;

namespace Ngaq.Core.Word.Models.Learn_;

public  partial struct Learn(str V)
	:IEquatable<Learn>
{
	public str Value{get;set;} = V;

	public static implicit operator str(Learn e){
		return e.Value;
	}
	public static implicit operator Learn(str s){
		return new Learn(s);
	}

	public override bool Equals([NotNullWhen(true)] object? obj) {
		return obj is Learn learn && Value.Equals(learn.Value);
	}

	public bool Equals(Learn other) {
		return Value.Equals(other.Value);
	}

	public override int GetHashCode() {
		return Value.GetHashCode();
	}

}
