#if false
//不能寫using語句 否則源生成 謬
partial struct PLACEHOLDERID
	:Ngaq.Core.Infra.IF.IIdUInt128
	,IEquatable<PLACEHOLDERID>
{
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
