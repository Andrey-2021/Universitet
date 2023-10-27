namespace EntitiesLibrary;

/// <summary>
/// Зарегистрированный пользователь
/// </summary>
public class InputUserDTO : IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Login
	/// </summary>
	public string? Login { get; set; }

	/// <summary>
	/// Пароль
	/// </summary>
	public string? Password { get; set; }

}
