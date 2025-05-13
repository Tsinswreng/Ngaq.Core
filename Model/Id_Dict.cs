namespace Ngaq.Core.Model;

public struct Id_Dict<T>(
	T Id
	, Dictionary<string, object> Dict
){
	public T Id{get;set;} = Id;
	public Dictionary<string, object> Dict{get;set;} = Dict;
}
