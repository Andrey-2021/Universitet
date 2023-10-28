using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace EntitiesLibrary;

/// <summary>
/// Базовый класс для реализации интерфейса INotifyPropertyChanged
/// </summary>
public abstract class BaseNotifyPropertyChanged: INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(prop));

		}
	}
}
