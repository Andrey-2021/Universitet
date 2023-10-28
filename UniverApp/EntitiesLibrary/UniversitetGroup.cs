namespace EntitiesLibrary;

/// <summary>
/// Учебная группа
/// </summary>
public class UniversitetGroup : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get => id; set { id = value; OnPropertyChanged(); } }
	public int id;

	/// <summary>
	/// Название группы
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введено название")]
	[StringLength(150, MinimumLength = 5, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
	[Comment("Название группы")]
	public string? Name
	{
		get => name;
		set
		{
			name = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? name;

	/// <summary>
	/// Описание
	/// </summary>
	[MaxLength(500, ErrorMessage = "Длина описания не должна превышать {1} символов")]
	public string? Description
	{
		get => description;
		set
		{
			description = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? description;

	/// <summary>
	/// Предметы изучаемые в Группе
	/// </summary>
	public List<Subject>? Subjects { get => subjects; set { subjects = value; OnPropertyChanged(); } }
	public List<Subject>? subjects;

	public List<Student>? Students{ get => students; set { students = value; OnPropertyChanged(); } }
	public List<Student>? students;
}
