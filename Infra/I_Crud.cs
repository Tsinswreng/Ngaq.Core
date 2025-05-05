using Ngaq.Core.Infra.Core;

namespace Ngaq.Core.Infra;

public interface I_Crud<T>{
	Task<I_Answer<nil>> AddManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<T?>> SeekByIdAsy<T_Id>(T_Id Id);
	Task<I_Answer<nil>> UpdateManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<nil>> DeleteManyByIdAsy(IEnumerable<object> IdList);


}
