namespace Ngaq.Core.Infra;
using TStruct = Tempus;
using TPrimitive = i64;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public partial struct Tempus(TPrimitive V)
	:IEquatable<Tempus>
	,I_Value<TPrimitive>
	,IDictSerializable
{
	public static TStruct Zero = new(0);
	public TPrimitive Value{get;set;} = V;

	public Tempus():this(DateTimeOffset.Now.ToUnixTimeMilliseconds()){

	}

	obj? I_ToSerialized.ToSerialized(obj? Obj){
		if(Obj is Tempus T){
			return T.Value;
		}
		return Obj;
	}

	obj? I_ToDeSerialized.ToDeSerialized(obj? Obj) {
		if(Obj is i64 I64){
			return new Tempus(I64);
		}
		if(Obj is DateTime Dt){
			return FromDateTime(Dt);
		}
		return Obj;
	}

	public static TStruct FromUnixMs(i64 Ms ){
		return new (Ms);
	}

	public static TStruct FromDateTime(DateTime dt){
		long ms = new DateTimeOffset(dt).ToUnixTimeMilliseconds();
		return FromUnixMs(ms);
	}

	public static TStruct Now(){
		return new TStruct();
	}

	public static TStruct FromIso(str Iso){
		return DateTimeOffset.ParseExact(
			Iso
			,"yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture
		).ToUnixTimeMilliseconds();
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

public class InMillisecond{
	public const i64 Second = 1000;
	public const i64 Minute = 60 * Second;
	public const i64 Hour = 60 * Minute;
	public const i64 Day = 24 * Hour;
	public const i64 Week = 7 * Day;
	public const i64 Month = 30 * Day;
	public const i64 Year = 365 * Day;
}

public static class ExtnTempus{
	public static str ToIso(this Tempus z){
		return DateTimeOffset.FromUnixTimeMilliseconds(z.Value)
		.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture);
	}
}
