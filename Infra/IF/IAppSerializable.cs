using System.Collections;

namespace Ngaq.Core.Infra.IF;

public interface IAppSerializable{
	// public obj? Serialize(){
	// 	return this;
	// }
	// public obj? Deserialize(obj? Src, obj Tar){
	// 	return Src;
	// }
}

// public static class ExtnSerializable{
// //type TSerialize = null|number|string|bool|IDict<str, TSerialize>|IList<TSerialize>

// 	static bool IsIListOfT(Type t){
// 		return t.GetInterfaces().Any(i =>
// 			i.IsGenericType &&
// 			i.GetGenericTypeDefinition() == typeof(IList<>)
// 		);
// 	}

// 	public static obj? Serialize(
// 		Type Type
// 		,obj? Src
// 	){
// 		if(Src == null){
// 			return null;
// 		}

// 		if(Src ){

// 		}else if(IsIListOfT(Type)){

// 		}
// 	}

// 	public static IDictionary<str, obj?> SerializeToDict(
// 		this IAppSerializable obj
// 	){
// 		var Mapper = CoreDictMapper.Inst;
// 		var ShallowDict = Mapper.ToDictShallow(obj.GetType(), obj);
// 		foreach(var (k,v) in ShallowDict){
// 			if(v is IEnumerable list){
// 				foreach(var item in list){
// 					//ShallowDict[k] = item.
// 				}
// 			}else if(v is IAppSerializable s){
// 				ShallowDict[k] = s.SerializeToDict();
// 			}else if(v is IIdUInt128){
// 				ShallowDict[k] = v.ToString();
// 			}else if(v is I_ValueObj vo){
// 				ShallowDict[k] = vo.ValueObj;
// 			}
// 		}
// 		return ShallowDict;
// 	}

// 	//需AOT下判斷某Type是否潙某接口ʹ子
// 	// public static obj Deserialize(
// 	// 	IDictionary<str, obj?> Dict
// 	// 	,Type Type
// 	// 	,obj R
// 	// ){
// 	// 	var Mapper = CoreDictMapper.Inst;
// 	// 	var TypeDict = Mapper.GetTypeDictShallow(Type);
// 	// 	foreach(var (k, type) in TypeDict){
// 	// 		var v = Dict[k];

// 	// 		if(){
// 	// 			Dict[k] = Deserialize(Dict, type, v);
// 	// 		}else if(v is I_ValueObj vo){

// 	// 		}
// 	// 	}
// 	// }
// }
