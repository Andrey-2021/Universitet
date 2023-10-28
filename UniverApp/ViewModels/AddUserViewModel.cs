using EntitiesLibrary.Enums;
namespace ViewModels;

public class AddUserViewModel : BaseAddEntityViewModel<RegisteredUser>
{
	public Dictionary<RoleEnum, string> RolesList => TranslateRoleEnum.Roles;

	//public KeyValuePair<RoleEnum, string> SelectedRole{get;set;}

	public AddUserViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		

	}

	protected override async void Save(object? parametr)
	{
		var entity=await repository.FindEntityAsync<RegisteredUser>(x => x.Login == MainEntity.Login);
		
		if (entity.ex != null) 
		{
			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "Ошибка при проверке данных. Попробуйте выполнить операцию позже или обратитесь к администратору";
			view.ShowDialog();
			return;
		}

		if (entity.entity != null)
		{
			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "Такой логин уже существует, придумайте другой";
			view.ShowDialog();
			return;
		}

		base.Save(parametr);
	}
}