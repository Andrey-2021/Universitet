using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EntitiesLibrary;

/// <summary>
/// Студент
/// </summary>
public class Student : INotifyPropertyChanged, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string? Surname { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }

	[NotMapped]
	public string? FIO => Surname + " " + Name?[0] + "." + MiddleName?[0] + ".";

	/// <summary>
	/// День рождения
	/// </summary>
	public DateTime? Birthday { get; set; }

	/// <summary>
	/// Ссылка на Группу в которой учится Студени
	/// </summary>
	public int? UniversitetGroupId {  get; set; }

	/// <summary>
	/// Группа в которой учится Студени
	/// </summary>
	public UniversitetGroup? UniversitetGroup {  get=> universitetGroup; set { universitetGroup = value; OnPropertyChanged(); } } //навигационное свойство, связано с UniversitetGroupId
	public UniversitetGroup? universitetGroup;

	/// <summary>
	/// Информация о днях посещения студентом занятий
	/// </summary>
	public List<Attendance>? Attendances { get; set; } //Навигационное свойство на таблицу Attendances

	/// <summary>
	/// Оценки студента
	/// </summary>
	public List<SubjectScore>? SubjectScores { get; set; } //Навигационное свойство на таблицу SubjectScore


	//Реализация INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(prop));
	}
}

