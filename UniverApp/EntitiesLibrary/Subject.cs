namespace EntitiesLibrary;

/// <summary>
/// Предмет, изучаемая дисциплина
/// </summary>
public class Subject : IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Название предмета
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public string? Description { get; set; }

    public List<UniversitetGroup>? UniversitetGroups { get; set; }

	/// <summary>
	/// Оценки студентов по предмету
	/// </summary>
	public List<SubjectScore>? SubjectScores { get; set; } //Навигационное свойство на таблицу SubjectScore
}
