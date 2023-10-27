namespace EntitiesLibrary;

/// <summary>
/// Тип задания (опросы, практические работы, самостоятельные работы,,,)
/// </summary>
public class TaskType : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Название
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введено название")]
	[StringLength(150, MinimumLength = 5, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
	[Comment("Название для типа задания (опросы, практические работы, самостоятельные работы,,,)")]
	public string? Name 
	{ 
		get=> name; 
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
	/// Оценки студентов
	/// </summary>
	public List<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } } //Навигационное свойство на таблицу SubjectScore
	public List<SubjectScore>? subjectScores;

}
