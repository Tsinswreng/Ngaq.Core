namespace Ngaq.Core.Infra;
using TStruct = Tempus;
using TPrimitive = i64;
using System.Diagnostics.CodeAnalysis;


public partial struct Tempus(TPrimitive V)
	:IEquatable<Tempus>
	,I_Value<TPrimitive>
{
	public TPrimitive Value{get;set;} = V;

	public Tempus():this(DateTimeOffset.Now.ToUnixTimeMilliseconds()){

	}

	public static Tempus FromUnixMs(i64 Ms ){
		return new Tempus(Ms);
	}

	public static Tempus FromDateTime(DateTime dt){
		long ms = new DateTimeOffset(dt).ToUnixTimeMilliseconds();
		return FromUnixMs(ms);
	}

	public static Tempus Now(){
		return new Tempus();
	}

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

