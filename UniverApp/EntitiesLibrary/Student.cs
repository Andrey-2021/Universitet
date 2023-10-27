namespace EntitiesLibrary;

/// <summary>
/// Студент
/// </summary>
public class Student : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введена фамилия")]
	[StringLength(30, MinimumLength = 5, ErrorMessage = "Длина фамилии имени быть не менее {2} и не более {1} символов")]
	[Comment("Фамилия студента")]
	public string? Surname
	{
		get => surname;
		set
		{
			surname = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? surname;


	/// <summary>
	/// Имя
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введено имя")]
	[StringLength(30, MinimumLength = 5, ErrorMessage = "Длина имени имени быть не менее {2} и не более {1} символов")]
	[Comment("Имя студента")]
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
	/// Отчество
	/// </summary>
		[Required(ErrorMessage = "Обязательно должна быть введено отчество")]
	[StringLength(30, MinimumLength = 5, ErrorMessage = "Длина отчества имени быть не менее {2} и не более {1} символов")]
	[Comment("Отчество студента")]
	public string? MiddleName
	{
		get => middleName;
		set
		{
			middleName = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? middleName;

	/// <summary>
	/// Фамилия И.О.
	/// </summary>
	[NotMapped]
	public string? FIO => Surname + " " + Name?[0] + "." + MiddleName?[0] + ".";

	/// <summary>
	/// День рождения
	/// </summary>
	public DateTime? Birthday
	{
		get => birthday;
		set
		{
			birthday = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private DateTime? birthday;

	/// <summary>
	/// Ссылка на группу в которой учится студени
	/// </summary>
	[Required(ErrorMessage = "Для стенда обязательно должена быть выбрана группа, в которой он учится")]
	[Range(1, int.MaxValue, ErrorMessage = "Не выбрана группа")]
	[Comment("Ссылка на группу")]
	public int UniversitetGroupId { get => universitetGroupId; set { universitetGroupId = value; OnPropertyChanged(); } }
	public int universitetGroupId;

	/// <summary>
	/// Группа в которой учится Студени
	/// </summary>
	public UniversitetGroup? UniversitetGroup {  get=> universitetGroup; set { universitetGroup = value; OnPropertyChanged(); } } //навигационное свойство, связано с UniversitetGroupId
	public UniversitetGroup? universitetGroup;

	/// <summary>
	/// Информация о днях посещения студентом занятий
	/// </summary>
	public List<Attendance>? Attendances { get => attendances; set { attendances = value; OnPropertyChanged(); } } //Навигационное свойство на таблицу Attendances
	public List<Attendance>? attendances;

	/// <summary>
	/// Оценки студента
	/// </summary>
	public List<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } }//Навигационное свойство на таблицу SubjectScore
	public List<SubjectScore>? subjectScores;

}

