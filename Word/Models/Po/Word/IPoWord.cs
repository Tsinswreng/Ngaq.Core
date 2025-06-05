//#define Impl
using Ngaq.Core.Model.Sys.Po.User;

public interface IHeadLangWord{

	#region IHeadLangWord

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

	public IdUser Owner{get;set;}

	#endregion IHeadLangWord
}
