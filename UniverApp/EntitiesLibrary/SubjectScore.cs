namespace EntitiesLibrary;

/// <summary>
/// оценка по предмету
/// </summary>
public class SubjectScore:IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Студент
	/// </summary>
	public int StudentId { get; set; }
	public Student? Student { get; set; }

	/// <summary>
	/// Предмет
	/// </summary>
	public int SubjectId { get; set; }
	public Subject? Subject { get; set; }

	/// <summary>
	/// Дата учёбы
	/// </summary>
	public int LearningDateId { get; set; }
	public LearningDate? LearningDate { get; set; }

	/// <summary>
	/// Тип задания/контрольной
	/// </summary>
	public int TaskTypeId { get; set; }
	public TaskType? TaskType { get; set; }

	/// <summary>
	/// Оценка
	/// </summary>
	public int Score { get; set; }
}
