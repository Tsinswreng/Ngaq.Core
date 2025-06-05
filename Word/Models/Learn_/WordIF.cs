namespace Ngaq.Core.Service.Word.Learn_.Models;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Kv;
using Ngaq.Core.Model.Po.Word;

public interface I_Id:I_Id<IdWord>{

}

public interface I_Index{
	public i64? Index{get;set;}
}

public interface I_Weight{
	public f64 Weight{get;set;}
}




