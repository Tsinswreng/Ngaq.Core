namespace Ngaq.Core.Infra;

using System.Collections;
using Tsinswreng.CsDictMapper;

public class Seria{
	public IDictMapperShallow DictMapper{get;set;}
	public bool IsPrimitive(Type Type){
		return Type.IsPrimitive || Type == typeof(string) || Type == typeof(decimal) || Type == typeof(DateTime) || Type == typeof(TimeSpan);
	}
	public obj? Serialize(obj? Obj, Type Type){
		if(Obj == null){
			return null;
		}
		if(IsPrimitive(Type)){
			return Obj;
		}
		if(Type.IsEnum){
			//TODO 按實ʹ底層數字類型來處理
			return Convert.ToInt64(Obj);
		}

		#region Custom
		if(Obj is I_ToSerialized s){
			return s.ToSerialized(Obj);
		}
		#endregion Custom


		{
			if(Obj is IEnumerable list){
				var R = new List<obj>();
				foreach(var ele in list){
					R.Add(Serialize(ele, ele.GetType())!);
				}
				return R;
			}
		}
		{
			var Dict = CoreDictMapper.Inst.ToDictShallow(Type, Obj);
			var Key_Type = CoreDictMapper.Inst.GetTypeDictShallow(Type);
			var R = new Dictionary<str, obj>();
			foreach(var (k,v) in Dict){
				R[k] = Serialize(v, Key_Type[k])!;
			}
			return R;
		}
	}

	//public obj AssignShallow(Type Type, obj? Obj, IDictionary<str, obj?> Dict);
	public obj? Deserialize(
		obj? SrcObj
		,Type TarType
		,ref obj TarObj
		,IDictionary<str, obj?>? Prop = null
	){
		if(SrcObj == null){
			TarObj = null!;
			return null;
		}
		if(IsPrimitive(TarType)){
			TarObj = SrcObj;
			return TarObj;
		}
		if(TarType.IsEnum){
			//TODO 按實ʹ底層數字類型來處理
			TarObj = Enum.ToObject(TarType, Convert.ToInt64(SrcObj));
			return TarObj;
		}
		#region Custom
		{
			if(TarObj is I_ToDeSerialized v){ //typeof(IIdUInt128).IsAssignableFrom(TarType)
				TarObj = v.ToDeSerialized(SrcObj)!;
				return TarObj;
			}
		}
		#endregion Custom
		{ //TODO 處理列表反序列化 需依賴額外ʹ源生成器、現有ʹDictMapper不夠。
			// var TOfList = ListDictOfT.GetTOfIList(TarType);
			// if(
			// 	SrcObj is IList srcList
			// 	&& TarObj is IList TarCol
			// 	&& TOfList is not null
			// ){
			// 	foreach(var ele in srcList){

			// 	}
			// }
			// if(
			// 	SrcObj is IEnumerable srcList
			// 	&& TarObj is IEnumerable tarList
			// ){
			// 	var R = new List<obj>();
			// 	ZipTwo(srcList, tarList, (s, t)=>{
			// 		R.Add(Deserialize(s, t.GetType(), ref t, Prop)!);
			// 		return 0;
			// 	});
			// 	TarObj = R;
			// 	return TarObj;
			// }
		}
		{
			if(
				SrcObj is IDictionary srcDict
				&& TarObj is not IDictionary
			){
				var Key_Type = DictMapper.GetTypeDictShallow(TarType);
				var TarDict = DictMapper.ToDictShallow(TarType, TarObj);
				foreach(DictionaryEntry kv in srcDict){
					obj? k=null,v=null;str kStr="";
					try{
						k = kv.Key;v = kv.Value;
						if(k is not str){continue;}
						kStr = (str)k;
						if(TarDict.TryGetValue(kStr, out var TarV)){
							var TarPropType = Key_Type[kStr];
							TarDict[kStr] = Deserialize(v, TarPropType, ref TarV!, Prop);
						}
					}
					catch (System.Exception e){
						throw new System.Exception($"Deserialize key:{kStr} value:{v} failed.", e);
					}
				}

				TarObj = DictMapper.AssignShallow(TarType, TarObj, TarDict);
				return TarObj;
			}
		}

		throw new Exception("Unknow type.");
		//return TarObj;
	}

	/// <summary>
	/// 同時遍歷兩個IEnumerable<T>
	/// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <param name="first"></param>
	/// <param name="second"></param>
	/// <param name="body"></param>
	public static void ZipTwo<T1, T2>(
		IEnumerable<T1> first,
		IEnumerable<T2> second,
		Func<T1, T2, int> body
	){
		using var e1 = first.GetEnumerator();
		using var e2 = second.GetEnumerator();
		while (e1.MoveNext() && e2.MoveNext()){
			var R = body(e1.Current, e2.Current);
			if(R != 0){
				break;
			}
		}
	}

	public static void ZipTwo(
		IEnumerable first,
		IEnumerable second,
		Func<obj,obj, int> body
	){
		var e1 = first.GetEnumerator();
		var e2 = second.GetEnumerator();
		while (e1.MoveNext() && e2.MoveNext()){
			var R = body(e1.Current, e2.Current);
			if(R != 0){
				break;
			}
		}
	}
}
