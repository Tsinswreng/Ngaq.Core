namespace Ngaq.Core.Infra.Errors;

// public record Status_Ns(
// 	///number or string
// 	object Status
// 	,string? Ns
// ):IStatus_Ns;

public  partial struct TypedStatus()
	:IEquatable<TypedStatus>
	,ITypedStatus
{
	public object Status{get;set;} = "";
	public str? StatusType{get;set;} = "";

	public override bool Equals(object? obj){
		return obj is TypedStatus other && Equals(other);
	}

	public bool Equals(TypedStatus other){
		return string.Equals(Status, other.Status) && string.Equals(StatusType, other.StatusType);
	}

	public override int GetHashCode() {
		unchecked{
			int hash = 17;
			hash = hash * 23 + (Status != null ? Status.GetHashCode() : 0);
			hash = hash * 23 + (StatusType != null ? StatusType.GetHashCode() : 0);
			return hash;
		}
	}

	public override string ToString() {
		if(StatusType != ""){
			return $"{StatusType}:{Status}";
		}
		return Status+"";
	}
	public static bool operator ==(TypedStatus left, TypedStatus right) {
		return left.Equals(right);
	}

	public static bool operator !=(TypedStatus left, TypedStatus right) {
		return !(left == right);
	}
}

