using System.Collections;
using Ngaq.Core.Infra.IF;
using Tsinswreng.CsDictMapper;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Infra;

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
		// {
		// 	if(Obj is IIdUInt128 v){
		// 		return v.ToString();
		// 	}
		// }
		// {
		// 	if(Obj is UInt128 v){
		// 		return ToolUInt128.ToLow64Base(v);
		// 	}
		// }
		// {
		// 	if(Obj is I_ValueObj v){ //TODO 勿硬編碼、設自定義類型序列化器
		// 		return v.ValueObj;
		// 	}
		// }
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
	public obj? Deserialize(obj? SrcObj, Type TarType, ref obj TarObj){
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
		{
			if(
				SrcObj is IEnumerable srcList
				&& TarObj is IEnumerable tarList
			){
				var R = new List<obj>();
				ZipTwo(srcList, tarList, (s, t)=>{
					R.Add(Deserialize(s, t.GetType(), ref t)!);
					return 0;
				});
				TarObj = R;
				return TarObj;
			}
		}
		{
			if(
				SrcObj is IDictionary srcDict
				&& TarObj is not IDictionary
			){
				var Key_Type = DictMapper.GetTypeDictShallow(TarType);
				var TarDict = DictMapper.ToDictShallow(TarType, TarObj);
				foreach(DictionaryEntry kv in srcDict){
					var k = kv.Key;var v = kv.Value;
					if(k is not str){continue;}
					var kStr = (str)k;
					if(TarDict.TryGetValue(kStr, out var TarV)){
						var TarPropType = Key_Type[kStr];
						TarDict[kStr] = Deserialize(v, TarPropType, ref TarV);
					}
				}
				TarObj = DictMapper.AssignShallow(TarType, TarObj, TarDict);
				return TarObj;
			}
		}
		//throw new NotImplementedException();
		System.Console.WriteLine("Unknow type:");
		System.Console.WriteLine("SrcObj: "+SrcObj);
		System.Console.WriteLine("SrcObj.GetType(): "+SrcObj.GetType());
		System.Console.WriteLine("TarObj: "+TarObj);
		System.Console.WriteLine("TarObj.GetType(): "+TarObj.GetType());
		System.Console.WriteLine("TarType: "+TarType);
		return TarObj;//TODO
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
