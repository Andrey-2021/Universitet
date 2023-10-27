using EntitiesLibrary.Enums;
namespace ViewModels;

public class AddUserViewModel : BaseAddEntityViewModel<RegisteredUser>
{
	public Dictionary<RoleEnum, string> RolesList => TranslateRoleEnum.Roles;

	//public KeyValuePair<RoleEnum, string> SelectedRole{get;set;}

	public AddUserViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		
	}
}