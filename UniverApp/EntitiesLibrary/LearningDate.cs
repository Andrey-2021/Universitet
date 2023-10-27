namespace EntitiesLibrary;

/// <summary>
/// Дата учёбы
/// </summary>
public class LearningDate : IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Дата учёбы
	/// </summary>
	public DateTime? Date { get; set; }

	/// <summary>
	/// Это учебный день. true - да, в этот день учатся
	/// </summary>
	public bool IsLearning { get; set; } = true;

	/// <summary>
	/// Оценки студентов на дату
	/// </summary>
	public List<SubjectScore>? SubjectScores { get; set; } //Навигационное свойство на таблицу SubjectScore
}
