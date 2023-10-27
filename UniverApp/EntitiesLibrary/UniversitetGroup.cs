using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace EntitiesLibrary;

/// <summary>
/// Учебная группа
/// </summary>
public class UniversitetGroup : INotifyPropertyChanged, IHaveId
{
	public int Id { get=> id; set { id = value; OnPropertyChanged(); } }
	public int id;

	/// <summary>
	/// Название группы
	/// </summary>
	public string? Name { get=> name; set { name = value; OnPropertyChanged(); } }
	public string? name;

	/// <summary>
	/// Описание
	/// </summary>
	public string? Description { get=> description; set { description = value; OnPropertyChanged(); } }
	public string? description;

	public List<Subject>? Subjects { get=> subjects; set { subjects = value; OnPropertyChanged(); } }
	public List<Subject>? subjects;

	//Реализация INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(prop));
	}

}
