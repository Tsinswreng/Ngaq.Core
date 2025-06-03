using System.Diagnostics.CodeAnalysis;

namespace Ngaq.Core.Service.Word.Learn_.Models;

public struct Learn(str V)
	:IEquatable<Learn>
{
	public str Value{get;set;} = V;

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
