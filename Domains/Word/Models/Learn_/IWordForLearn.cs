namespace Ngaq.Core.Word.Models.Learn_;
using System.ComponentModel;
using Ngaq.Core.Models.Po;
using Ngaq.Core.Word.Models.Po.Word;


public partial interface IWordForLearn
	:I_Id
	,IPoBase
	,IHeadLangWord
	,I_Index
	,I_Weight
	,I_Learn_Records
	,I_StrKey_Props
	,I_LearnRecords
	,I_PrevTurnLearnRecords
	,I_UnsavedLearnRecords
	,INotifyPropertyChanged
	,I_OnPropertyChanged //在類外觸發事件
	,I_ShallowCloneSelf
{

}
