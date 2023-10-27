﻿using DbLibrary;
using Microsoft.Extensions.DependencyInjection;
namespace ViewModels;

public class CheckLoginViewModel : BaseAddEntityViewModel<CheckLogin>
{
	/// <summary>
	/// Флаг что проверка прошла
	/// </summary>
	public bool IsCkeckOn { get; private set; } = false;

	public CheckLoginViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}

	protected override async void Save(object? parametr)
	{
		var connectionError= await repository.CanConnectAsync();
		
		if(connectionError != null) //ошибка соединения с БД
		{
			if (MainEntity.Password =="admin" && MainEntity.Login=="admin")
			{
				var errorView = serviceProvider.GetRequiredService<IMessageWindowView>();
				errorView.ViewModel.Parametr = "БД недоступна/отсутствует. Вам предоставляется доступ в программу, создайте новую БД и смените пароли по умолчанию.";
				errorView.ShowDialog();

				IsCkeckOn = true;
				CloseWindow(parametr);
				return;
			}

			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "БД недоступна. Неправильно ввели пароль или логин!";
			view.ShowDialog();
			IsCkeckOn = false;
			CloseWindow(parametr);
			return;

		}

		var find= await repository.GetEntitiesAsync<RegisteredUser>(x => x.Password == MainEntity.Password && x.Login == MainEntity.Login);
		if(find== null || find.Count==0)
		{
			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "Неправильно ввели пароль или логин!";
			view.ShowDialog();
			IsCkeckOn = false;
			CloseWindow(parametr);
			return;
		}

		IsCkeckOn = true;
		CloseWindow(parametr);//всё хорошо, закрываем  окно
	}
}
