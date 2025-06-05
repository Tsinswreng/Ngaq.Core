using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ngaq.Core.Word.Models.Learn_;

public interface I_OnPropertyChanged: INotifyPropertyChanged{
	void OnPropertyChanged(str? PropName);
	// public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null){
	// 	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	// }
}

