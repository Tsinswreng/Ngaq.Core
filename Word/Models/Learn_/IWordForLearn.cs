using System.ComponentModel;
using Ngaq.Core.Model.Po.Word;

namespace Ngaq.Core.Word.Models.Learn_;

public interface IWordForLearn
	:IPoWord
	,I_Id
	,I_Weight
	,I_Learn_Records
	,I_StrKey_Props
	,I_SavedLearnRecords
	,I_UnsavedLearnRecords
	,INotifyPropertyChanged
	,I_OnPropertyChanged //在類外觸發事件
{

}
