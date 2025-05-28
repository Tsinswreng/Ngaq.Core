//#define Impl
public interface IPoWord{

	#region I_Po_Word

	/// <summary>
	/// 詞形標識
	/// </summary>
	public str Head{get;set;}
	#if Impl
		="";
	#endif


	public str Lang{get;set;}
	#if Impl
		="";
	#endif

	#endregion I_Po_Word
}
