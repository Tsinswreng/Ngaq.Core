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
		Value = Ngaq.Core.Tools.ToolId.NewGuidV7UInt128();
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


	// 在FromLow64Base方法后添加以下代码
	/// <summary>
	/// 将Low64Base编码的字符串解析为PLACEHOLDERID
	/// </summary>
	/// <param name="s">Low64Base编码的字符串</param>
	/// <returns>解析得到的PLACEHOLDERID</returns>
	/// <exception cref="ArgumentException">当输入字符串无效时抛出</exception>
	public static PLACEHOLDERID Parse(string S){
		return FromLow64Base(S);
	}

	/// <summary>
	/// 尝试将Low64Base编码的字符串解析为PLACEHOLDERID
	/// </summary>
	/// <param name="S">Low64Base编码的字符串</param>
	/// <param name="R">解析成功时返回的PLACEHOLDERID，失败时为默认值</param>
	/// <returns>解析成功返回true，失败返回false</returns>
	public static bool TryParse(string? S, out PLACEHOLDERID R){
		if(S is null){
			R = default!;
			return false;
		}
		if(Tsinswreng.CsTools.ToolUInt128.TryLow64BaseToUInt128(S, out var Num)){
			R = new PLACEHOLDERID(Num);
			return true;
		}
		R = default!;
		return false;
	}

}

#endif
