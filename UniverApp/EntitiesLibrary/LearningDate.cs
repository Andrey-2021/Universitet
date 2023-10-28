namespace EntitiesLibrary;

/// <summary>
/// Дата учёбы
/// </summary>
public class LearningDate : BaseINotifyDataErrorInfo,IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Дата учёбы
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть указана дата")]
	[Comment("Дата учёбы")]
	public DateTime Date
	{
		get => date;
		set
		{
			date = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private DateTime date;


	/// <summary>
	/// Это учебный день. true - да, в этот день учатся
	/// </summary>
	public bool IsLearning
	{
		get => isLearning;
		set
		{
			isLearning = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private bool isLearning;

	/// <summary>
	/// Оценки студентов на дату
	/// </summary>
	public List<SubjectScore>? SubjectScores//Навигационное свойство на таблицу SubjectScore
	{
		get => subjectScores;
		set
		{
			subjectScores = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private List<SubjectScore>? subjectScores;
}
