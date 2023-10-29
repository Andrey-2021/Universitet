namespace EntitiesLibrary.Auxiliaries;

/// <summary>
/// Средняя оценка студента
/// </summary>
public class StudentAverageScore
{
	/// <summary>
	/// Студент
	/// </summary>
    public Student Student { get; set; }
    
	/// <summary>
	/// Средняя оценка
	/// </summary>
	public decimal AverageScore { get; set; }

	public StudentAverageScore(Student student, decimal averageScore)
	{
		Student = student;
		AverageScore = averageScore;
	}		
}
