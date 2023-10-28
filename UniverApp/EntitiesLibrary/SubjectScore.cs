namespace EntitiesLibrary;

/// <summary>
/// оценка по предмету
/// </summary>
public class SubjectScore : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Студент
	/// </summary>
	[Range(1, int.MaxValue, ErrorMessage= "Обязательно должен быть выбран студент")]
	[Required(ErrorMessage = "Обязательно должен быть указан студент")]
	[Comment("Ссылка на студента")]
	public int StudentId
	{
		get => studentId;
		set
		{
			studentId = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private int studentId;
	
	public Student? Student
	{
		get => student;
		set
		{
			student = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private Student? student;


	/// <summary>
	/// Предмет
	/// </summary>
	[Range(1, int.MaxValue, ErrorMessage= "Обязательно должен быть выбран предмет")]
	[Required(ErrorMessage = "Обязательно должн быть указан предмет")]
	[Comment("Ссылка на предмет")]
	public int SubjectId
	{
		get => subjectId;
		set
		{
			subjectId = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private int subjectId;

	public Subject? Subject
	{
		get => subject;
		set
		{
			subject = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private Subject? subject;


	/// <summary>
	/// Дата учёбы
	/// </summary>
	[Range(1, int.MaxValue, ErrorMessage = "Обязательно должена быть выбрана дата")]
	[Required(ErrorMessage = "Обязательно должна быть указана дата")]
	[Comment("Дата учёбы")]
	public int LearningDateId
	{
		get => learningDateId;
		set
		{
			learningDateId = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private int learningDateId;

	
	public LearningDate? LearningDate
	{
		get => learningDate;
		set
		{
			learningDate = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private LearningDate? learningDate;


	/// <summary>
	/// Тип задания/контрольной
	/// </summary>
	[Range(1, int.MaxValue, ErrorMessage = "Обязательно должен быть выбран тип задания/контрольной")]
	[Required(ErrorMessage = "Обязательно должн быть указан тип задания/контрольной")]
	[Comment("Ссылка на Тип задания/контрольной")]
	public int TaskTypeId
	{
		get => taskTypeId;
		set
		{
			taskTypeId = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private int taskTypeId;
	
	
	public TaskType? TaskType
	{
		get => taskType;
		set
		{
			taskType = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private TaskType? taskType;

	/// <summary>
	/// Оценка
	/// </summary>
	[Range(1, 5, ErrorMessage="Оценка может принимать значение от 1 до 5")]
	public int Score
	{
		get => score;
		set
		{
			score = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private int score;
}
