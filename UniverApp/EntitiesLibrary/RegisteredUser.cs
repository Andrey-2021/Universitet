namespace EntitiesLibrary;

/// <summary>
/// Данные вводимые при регистрации пользователя
/// </summary>
public class RegisteredUser:IHaveId
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

	[NotMapped]
	public string? ConfirmedPassword { get; set; }

	public RoleEnum? Role { get; set; }

}
