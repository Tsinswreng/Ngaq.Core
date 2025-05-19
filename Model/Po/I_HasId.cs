namespace Ngaq.Core.Model.Po;


// public interface I_GetId<out T>{
// 	public T Id{get;}
// }

// public interface I_SetId<in T>{
// 	public T Id{set;}
// }

public interface I_HasId<T>
	// :I_GetId<T>
	// ,I_SetId<T>
{
	public T Id { get; set; }
}
