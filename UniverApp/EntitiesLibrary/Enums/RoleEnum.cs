namespace EntitiesLibrary.Enums;

/// <summary>
/// Роли
/// </summary>
public enum RoleEnum
{
	/// <summary>
	/// Администратор
	/// </summary>
	admin=1,

	/// <summary>
	/// Менеджер
	/// </summary>
	manager=2
}


public class TranslateRoleEnum
{
	public static Dictionary<RoleEnum, string> Roles
	{
		get
		{
			return new Dictionary<RoleEnum, string>()
			{
				[RoleEnum.admin] = "Администратор",
				[RoleEnum.manager] = "Оператор"
			};
		}
	}
}