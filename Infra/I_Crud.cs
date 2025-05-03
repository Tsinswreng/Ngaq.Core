namespace Ngaq.Core.Infra;

public interface I_Crud<T>{
	Task<I_Answer<nil>> AddManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<T>> SeekByIdAsy(object Id);
	Task<I_Answer<nil>> UpdateManyAsy(IEnumerable<T> EntityList);
	Task<I_Answer<T>> DeleteManyByIdAsy(IEnumerable<object> IdList);


}
