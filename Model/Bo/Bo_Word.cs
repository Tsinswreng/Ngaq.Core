using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;

namespace Ngaq.Core.Model.Bo;

public class Bo_Word: I_Id<object>{
	public Po_Word Po_Word{get;set;}
	public IList<Po_Kv> Props{get;set;} = new List<Po_Kv>();
	public IList<Po_Kv> Learns{get;set;} = new List<Po_Kv>();

	public object Id{
		get{return Po_Word.Id;}
		set{Po_Word.Id = (Id_Word)value;}
	}


}
