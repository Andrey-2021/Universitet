namespace EntitiesLibrary.Services;

/// <summary>
/// Сервис выдаёт информацию о вошедшем пользователе.
/// Используется чтобы в программе можно было везде получить информацию о вошедшем пользователе
/// </summary>
public class LiginUserService
{
	public RegisteredUser? RegisteredUser { get; private set; }

	public void CreateAdmin(string login="admin", string password="admin")
	{
		RegisteredUser = new() { Login = login, Password = password, Role = RoleEnum.admin };
	}

	public void SetUser(RegisteredUser registeredUser)
	{
		RegisteredUser= registeredUser;
	}

}
