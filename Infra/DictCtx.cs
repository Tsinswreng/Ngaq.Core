using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml.Serialization;
using Ngaq.Core.Model.Bo;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;
using Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Word.Models.Po.Learn;
using Tsinswreng.CsDictMapper;
namespace Ngaq.Core.Infra;

[DictType(typeof(IPoKv))]
[DictType(typeof(PoWordProp))]
[DictType(typeof(PoWord))]
[DictType(typeof(PoWordLearn))]
[DictType(typeof(Prop))]
//[DictType(typeof(AppCfg))] //TargetType須惟一
// [DictType(typeof(AppCfg), true)]
// [DictType(typeof(AppCfg), Recursive = true)]
//[DictType(typeof(BoWord))]
//[DictType(typeof(TestParent))]
public partial class CoreDictMapper{
protected static CoreDictMapper? _Inst = null;
public static CoreDictMapper Inst => _Inst??= new CoreDictMapper();

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

public static class ExtnIDict{
	public static str Print<K,V>(
		IDictionary<K,V> z
	){
		List<str> res = new List<str>();
		foreach(var kvp in z){
			res.Add(kvp.Key + ":" + kvp.Value + "\n");
		}
		return str.Join("", res);
	}
}
