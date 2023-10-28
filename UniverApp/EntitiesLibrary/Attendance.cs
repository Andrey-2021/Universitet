namespace EntitiesLibrary;

/// <summary>
/// Посещаемость
/// </summary>
public class Attendance : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// ссылка на Студента
	/// </summary>
	[Required(ErrorMessage = "Обязательно должн быть указан студент")]
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

	/// <summary>
	/// Студент
	/// </summary>
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
	/// Дата учёбы, ссылка
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть указана дата")]
	[Comment("Ссылка на дату")]
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

	/// <summary>
	/// Дата учёбы
	/// </summary>
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
	/// Был в этот день на учёбе
	/// </summary>
	public bool IsWasToday
	{
		get => isWasToday;
		set
		{
			isWasToday = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private bool isWasToday;

}
