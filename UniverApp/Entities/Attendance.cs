using System;
namespace Entities;

/// <summary>
/// Посещаемость
/// </summary>
public class Attendance
{
	public int Id { get; set; }

	/// <summary>
	/// Дата
	/// </summary>
	public DateTime? Date { get; set; }
}
