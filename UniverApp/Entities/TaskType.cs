namespace Entities;

/// <summary>
/// Тип задания (опросы, практические работы, самостоятельные работы,,,)
/// </summary>
public class TaskType
{
	public int Id { get; set; }

	/// <summary>
	/// Название
	/// </summary>
	public string? Name { get; set; }
}
