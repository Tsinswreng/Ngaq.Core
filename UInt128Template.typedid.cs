#if false//改完後勿忘複製入UInt128Template.typedid
//不能寫using語句 否則源生成 謬
//叵續ˣ定義無參構造器、蓋源生成器生成旹默認已給構造器。
static class Extn{
	public static u8[] ToByteArr(this UInt128 z){
		return global::Tsinswreng.CsTools.ToolUInt128.ToByteArr(z);
	}
}
partial struct PLACEHOLDERID
	:Ngaq.Core.Infra.IF.IIdUInt128
	,IEquatable<PLACEHOLDERID>
	,IDictSerializable
{
	public static readonly PLACEHOLDERID Zero = default;
	public static Tsinswreng.CsSqlHelper.IUpperTypeMapFnT<u8[], PLACEHOLDERID> MkTypeMapFn(){
		return Tsinswreng.CsSqlHelper.UpperTypeMapFnT<u8[], PLACEHOLDERID>.Mk(
			(raw)=>PLACEHOLDERID.FromByteArr(raw)
			,(upper)=>upper.Value.ToByteArr()
		);
	}

	public static Tsinswreng.CsSqlHelper.IUpperTypeMapFnT<u8[]?, PLACEHOLDERID?> MkTypeMapFnNullable(){
		return Tsinswreng.CsSqlHelper.UpperTypeMapFnT<u8[]?, PLACEHOLDERID?>.Mk(
			(raw)=>raw==null?null:PLACEHOLDERID.FromByteArr(raw)
			,(upper)=>upper?.Value.ToByteArr()
		);
	}

	object? I_ToDeSerialized.ToDeSerialized(object? Obj) {
		if(Obj is str s){
			return FromLow64Base(s);
		}
		return Obj;
	}

	object? I_ToSerialized.ToSerialized(object? Obj) {
		if(Obj is PLACEHOLDERID){
			return Obj.ToString();
		}
		return Obj;
	}

	public PLACEHOLDERID():this(0){
		Value = Ngaq.Core.Tools.ToolId.NewUlidUInt128();
	}

	public static PLACEHOLDERID FromLow64Base(string Low64Base){
		var Num = Tsinswreng.CsTools.ToolUInt128.Low64BaseToUInt128(Low64Base);
		return new PLACEHOLDERID(Num);
	}

	public static PLACEHOLDERID FromByteArr(byte[] bytes){
		var Num = Tsinswreng.CsTools.ToolUInt128.ByteArrToUInt128(bytes);
		return new PLACEHOLDERID(Num);
	}

	public UInt128 Value { get; set; }

	public PLACEHOLDERID(UInt128 value) => Value = value;

	// public static explicit operator UInt128(PLACEHOLDERID id) => id.Value;
	// public static explicit operator PLACEHOLDERID(UInt128 value) => new(value);

	public static implicit operator UInt128(PLACEHOLDERID id) => id.Value;
	public static implicit operator PLACEHOLDERID(UInt128 value) => new(value);

	public override string ToString(){
		return Tsinswreng.CsTools.ToolUInt128.ToLow64Base(Value);
	}

	public static bool operator ==(PLACEHOLDERID left, PLACEHOLDERID right)
		=> left.Value == right.Value;

	public static bool operator !=(PLACEHOLDERID left, PLACEHOLDERID right)
		=> !(left == right);

	// 重写 object.Equals
	public override bool Equals(object? obj)
		=> obj is PLACEHOLDERID other && Equals(other);

	// 重写 GetHashCode
	public override int GetHashCode()
		=> Value.GetHashCode();

	public bool Equals(PLACEHOLDERID other) {
		return Value.Equals(other.Value);
	}
}

#endif
