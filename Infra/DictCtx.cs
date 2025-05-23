using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Learn;
using Ngaq.Core.Model.Po.Word;
using Tsinswreng.SrcGen.Dict;
using Tsinswreng.SrcGen.Dict.Attributes;
namespace Ngaq.Core.Infra;

[DictType(typeof(Po_Kv))]
[DictType(typeof(Po_Word))]
[DictType(typeof(Po_Learn))]
//[DictType(typeof(TestParent))]
public partial class DictCtx {

	public class DictMapper:IDictMapper{
		public IDictionary<str, object?> ToDictT<T>(T obj){
			return DictCtx.ToDictT(obj);
		}
		public T AssignT<T> (T obj, IDictionary<str, object?> dict){
			return DictCtx.AssignT(obj, dict);
		}
	}
	// public static IDictionary<str, object> ToDictT<
	// 	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	// 	T
	// >(T obj) {
	// 	var dict = new Dictionary<string, object>();
	// 	Type type = typeof(T);

	// 	System.Console.WriteLine("type: "+type.Name);//t
	// 	// 添加公共实例属性
	// 	foreach (var prop in type.GetProperties()) {// BindingFlags.Public | BindingFlags.Instance| BindingFlags.DeclaredOnly
	// 		System.Console.WriteLine("prop: "+prop.Name);//t
	// 		dict[prop.Name] = prop.GetValue(obj);
	// 	}

	// 	// 添加公共实例字段
	// 	foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance)) {// | BindingFlags.DeclaredOnly
	// 		dict[field.Name] = field.GetValue(obj);
	// 	}


	// 	// 遍历所有父类
	// 	// while (type != null) {

	// 	// 	//type = type.BaseType; // 向上遍历父类
	// 	// }
	// 	return dict;
	// }

	// public static T AssignT<T>(T obj, IDictionary<str, object> dict) {
	// 	Type type = typeof(T);
	// 	foreach (var kvp in dict) {
	// 		string key = kvp.Key;
	// 		object value = kvp.Value;

	// 		// 遍历所有父类
	// 		Type currentType = type;
	// 		while (currentType != null) {
	// 			// 查找属性
	// 			PropertyInfo prop = currentType.GetProperty(key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
	// 			if (prop != null && prop.CanWrite) {
	// 				prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
	// 				break;
	// 			}

	// 			// 查找字段
	// 			FieldInfo field = currentType.GetField(key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
	// 			if (field != null) {
	// 				field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
	// 				break;
	// 			}

	// 			currentType = currentType.BaseType; // 向上遍历父类
	// 		}
	// 	}
	// 	return obj;
	// }

}
