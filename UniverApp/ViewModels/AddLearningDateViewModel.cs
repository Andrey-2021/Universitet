namespace ViewModels;

public class AddLearningDateViewModel : BaseAddEntityViewModel<LearningDate>
{  
	/// <summary>
/// Флаг показывает что сейчас идёт создание нового объекта. Если = false - тогда идёт редактирование старого объекта
/// </summary>
	public bool IsAddNewMode { get=> isAddNewMode; set { isAddNewMode = value; OnPropertyChanged(); } }
	public bool isAddNewMode;

	public AddLearningDateViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		IsAddNewMode = true;
	}
	

	protected override async Task OperationsAfterSetParametrAsync(object? parametr)
	{
		if (parametr == null) IsAddNewMode = true;
		else IsAddNewMode = false;
	}


	protected override async void Save(object? parametr)
	{
		if (IsAddNewMode)
		{
			//ищем день с такой же датой
			var entity = await repository.FindEntityAsync<LearningDate>(x => x.Date.Year == MainEntity.Date.Year && x.Date.Month == MainEntity.Date.Month && x.Date.Day == MainEntity.Date.Day);


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
				view.ViewModel.Parametr = "Такой учебный день уже существует, введите другой";
				view.ShowDialog();
				return;
			}
		}

		base.Save(parametr);
	}
}
