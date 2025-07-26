namespace Ngaq.Core.Word.Models.Learn_;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Word;

public  partial interface I_Id:I_Id<IdWord>{

}

public  partial interface I_Index{
	public u64? Index{get;set;}
}

public  partial interface I_Weight{
	public f64? Weight{get;set;}
}

