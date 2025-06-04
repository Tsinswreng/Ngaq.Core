namespace Ngaq.Core.Infra.Errors;


public struct Id_Ns()
	:IEquatable<Id_Ns>
{
	public str Id = "";
	public str Ns = "";

	public override bool Equals(object? obj){
		return obj is Id_Ns other && Equals(other);
	}

	public bool Equals(Id_Ns other){
		return string.Equals(Id, other.Id) && string.Equals(Ns, other.Ns);
	}

	public override int GetHashCode() {
		unchecked{
			int hash = 17;
			hash = hash * 23 + (Id != null ? Id.GetHashCode() : 0);
			hash = hash * 23 + (Ns != null ? Ns.GetHashCode() : 0);
			return hash;
		}
	}

	public override string ToString() {
		if(Ns != ""){
			return $"{Ns}:{Id}";
		}
		return Id;
	}

}

