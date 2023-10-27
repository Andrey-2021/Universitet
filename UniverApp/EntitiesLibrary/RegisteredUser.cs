namespace EntitiesLibrary;

/// <summary>
/// Данные вводимые при регистрации пользователя
/// </summary>
public class RegisteredUser : BaseINotifyDataErrorInfo, IHaveId
{
	public int Id { get; set; }

	/// <summary>
	/// Login
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введен логин")]
	[StringLength(20, MinimumLength = 4, ErrorMessage = "Длина логина должна быть не менее {2} и не более {1} символов")]
	[Comment("Логин")]
	public string? Login
	{
		get => login;
		set
		{
			login = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? login;

	/// <summary>
	/// Пароль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть введен пароль")]
	[StringLength(20, MinimumLength = 4, ErrorMessage = "Длина пароля должна быть не менее {2} и не более {1} символов")]
	[Comment("Пароль")]
	public string? Password
	{
		get => password;
		set
		{
			password = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? password;

	/// <summary>
	/// Повторный пароль
	/// </summary>
	[NotMapped]
	//[Compare("Password", ErrorMessage ="Пароли не совпадают ")]
	public string? ConfirmedPassword
	{
		get => confirmedPassword;
		set
		{
			confirmedPassword = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private string? confirmedPassword;

	/// <summary>
	/// Роль
	/// </summary>
	[Required(ErrorMessage = "Обязательно должна быть указана роль")]
	[Comment("Роль")]
	public RoleEnum? Role
	{
		get => role;
		set
		{
			role = value;
			OnPropertyChanged();
			Validate(value);
		}
	}
	private RoleEnum? role;
}
