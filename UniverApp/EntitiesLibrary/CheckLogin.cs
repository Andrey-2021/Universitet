namespace EntitiesLibrary;

/// <summary>
/// для проверки входа по логину и паролю
/// </summary>
public class CheckLogin : BaseINotifyDataErrorInfo
{
	/// <summary>
	/// Login
	/// </summary>
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
}
