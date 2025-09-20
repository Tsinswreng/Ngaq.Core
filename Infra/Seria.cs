using System.Collections;
using Ngaq.Core.Infra.IF;
using Tsinswreng.CsTools;

namespace Ngaq.Core.Infra;

public class Seria{
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
		{
			if(Obj is IIdUInt128 v){
				return v.ToString();
			}
		}
		{
			if(Obj is UInt128 v){
				return ToolUInt128.ToLow64Base(v);
			}
		}
		{
			if(Obj is I_ValueObj v){ //TODO 勿硬編碼、設自定義類型序列化器
				return v.ValueObj;
			}
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
}
