namespace EntitiesLibrary;

/// <summary>
/// Предмет, изучаемая дисциплина
/// </summary>
public class Subject : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Название предмета
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введено название")]
	[StringLength(150, MinimumLength = 5, ErrorMessage = "Длина названия должна быть не менее {2} и не более {1} символов")]
	[Comment("Название предмета")]
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
	/// Группы университета в которых преподаётся предмет/дисциплина
	/// </summary>
	public List<UniversitetGroup>? UniversitetGroups { get => universitetGroups; set { universitetGroups = value; OnPropertyChanged(); } }
	public List<UniversitetGroup>? universitetGroups;

	/// <summary>
	/// Оценки студентов по предмету
	/// </summary>
	public List<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } } //Навигационное свойство на таблицу SubjectScore
	public List<SubjectScore>? subjectScores;
}
