using System.Collections;

namespace Ngaq.Core.Tools;

public interface IKvNode{
	public obj? ValueObj{get;set;}
	public IKvNode? this[int index] { get; set; }
	public IKvNode? this[str prop] { get; set; }
}


public struct KvNode:IKvNode{
	public KvNode(obj? Value){
		this.ValueObj = Value;
	}
	[Impl]
	public obj? ValueObj{get;set;}
	[Impl]
	public IKvNode? this[int index] {
		get{
			if(ValueObj is IList l){
				return new KvNode(l[index]);
			}
			return null;
		}
		set{
			if(ValueObj is IList l){
				l[index] = value;
			}
		}
	}
	[Impl]
	public IKvNode? this[str prop] {
		get{
			if(ValueObj is IDictionary d){
				return new KvNode(d[prop]);
			}
			return null;
		}
		set{
			if(ValueObj is IDictionary d){
				d[prop] = value;
			}
		}
	}
}
