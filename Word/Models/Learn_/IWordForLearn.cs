using System.ComponentModel;
using Ngaq.Core.Model.Po;
using Ngaq.Core.Model.Po.Word;
using Tsinswreng.CsCore.IF;

namespace Ngaq.Core.Word.Models.Learn_;

public interface IWordForLearn
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
