using EntitiesLibrary.Services;
namespace ViewModels;

public class CheckLoginViewModel : BaseAddEntityViewModel<CheckLogin>
{
	public CheckLoginViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}

	protected override async void Save(object? parametr)
	{
		 var loginUserService = serviceProvider.GetService<LiginUserService>();

		var connectionError= await repository.CanConnectAsync();
		
		if(connectionError != null) //ошибка соединения с БД
		{
			if (MainEntity.Password =="admin" && MainEntity.Login=="admin")
			{
				var errorView = serviceProvider.GetRequiredService<IMessageWindowView>();
				errorView.ViewModel.Parametr = "БД недоступна/отсутствует. Вам предоставляется доступ в программу, создайте новую БД и смените пароли по умолчанию.";
				errorView.ShowDialog();

				loginUserService!.CreateAdmin();
				CloseWindow(parametr);
				return;
			}

			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "БД недоступна. Неправильно ввели пароль или логин!";
			view.ShowDialog();
			CloseWindow(parametr);
			return;

		}

		var find= await repository.GetEntitiesAsync<RegisteredUser>(x => x.Password == MainEntity.Password && x.Login == MainEntity.Login);
		if(find== null || find.Count==0)
		{
			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "Неправильно ввели пароль или логин!";
			view.ShowDialog();
			CloseWindow(parametr);
			return;
		}

		loginUserService!.SetUser(find[0]);
		CloseWindow(parametr);//всё хорошо, закрываем  окно
	}
}
