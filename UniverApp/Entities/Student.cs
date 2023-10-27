namespace Entities;

public class Student
{
	public int Id { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string? Surname { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }
}
