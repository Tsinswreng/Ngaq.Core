//#define Impl
namespace Ngaq.Core.Word.Models.Po.Word;

using Ngaq.Core.Domains.User.Models.Po.User;

public partial interface IHeadLangWord{

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
