using Ngaq.Core.Infra.Core;
using Ngaq.Core.Model;

namespace Ngaq.Core.Infra;

public interface I_Crud<T>{
	Task<I_Answer<nil>> AddManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<T?>> SeekByIdAsy<T_Id>(T_Id Id);
	//Task<I_Answer<nil>> UpdateManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<nil>> UpdateManyAsy<T_Id>(IEnumerable<Id_Dict<T_Id>> Id_Dicts);
	Task<I_Answer<nil>> DeleteManyByIdAsy(IEnumerable<object> IdList);


}
