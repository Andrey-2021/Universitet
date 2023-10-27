namespace EntitiesLibrary;

/// <summary>
/// Посещаемость
/// </summary>
public class Attendance : IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Студент
	/// </summary>
	public int StudentId { get; set; }
	public Student? Student { get; set; }

	/// <summary>
	/// Дата учёбы
	/// </summary>
	public int LearningDateId { get; set; }
	public LearningDate? LearningDate { get; set; }


	/// <summary>
	/// Был в этот день на учёбе
	/// </summary>
	public bool IsWasToday { get; set; }

}
