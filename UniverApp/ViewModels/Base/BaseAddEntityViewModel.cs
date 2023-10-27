namespace ViewModels.Base;

/// <summary>
/// Базовый класс для всех AddViewModel
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseAddEntityViewModel<TEntity>: INotifyPropertyChanged, IViewModelWithParametr
	where TEntity : class, new()
{
	public bool IsBusy { get; set; }

	public object? Parametr { set => OnParametrSet(value); }

	/// <summary>
	/// Главная сущность/объект
	/// </summary>
	public TEntity? MainEntity { get=> mainEntity; set { mainEntity = value; OnPropertyChanged(); } }
	private TEntity? mainEntity;

	public string? Message { get; set; }

	/// <summary>
	/// Команда "Сохранить"
	/// </summary>
	public RelayCommand? SaveCommand { get; set; }
	
	/// <summary>
	/// Команда "Отмена/закрыть окно"
	/// </summary>
	public RelayCommand? CloseWindowCommand { get; set; }
	
	/// <summary>
	/// Контейнер
	/// </summary>
	protected IServiceProvider serviceProvider;
	
	/// <summary>
	/// Репозиторий для работы с БД
	/// </summary>
	protected DbRepository repository;
	
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public BaseAddEntityViewModel(IServiceProvider serviceProvider)
	{
		MainEntity = new();
		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД

		//настраиваем команды
		SaveCommand = new RelayCommand(Save, CheckIsPossibleSave);
		CloseWindowCommand = new RelayCommand(CloseWindow, CheckIsPossibleCloseWindow);
	}

	/// <summary>
	/// Приведение типов. Переданный параметр типа object приводим к типу TEntity
	/// </summary>
	/// <param name="parametr"></param>
	/// <exception cref="ArgumentException"></exception>
	protected virtual async void OnParametrSet(object? parametr)
	{
		var mainEntity = parametr as TEntity;
		if (mainEntity == null) throw new ArgumentException("Неправильно задан тип параметра");//если не удалость привести, бросаем исключение
		MainEntity = mainEntity;
		await OperationsAfterSetParametrAsync();
	}

	/// <summary>
	/// Опреации после получения параметра
	/// </summary>
	/// <returns></returns>
	protected virtual async Task OperationsAfterSetParametrAsync()
	{
		await Task.CompletedTask;
	}

	/// <summary>
	/// Сохранить данные. (Метод который вызывается командой SaveCommand)
	/// </summary>
	/// <param name="parametr"></param>
	protected virtual async void Save(object? parametr)
	{
		var result = await repository.UpdateEntityAsync(MainEntity);
		
		if (result!=null) //если ошибка
		{
			Message = "Ошибка";
			return;
		}
		CloseWindow(parametr);//всё хорошо, закрываем  окно
	}

	/// <summary>
	/// Проверка можно ли выполнять команду Сохранить
	/// </summary>
	/// <param name="parametr"></param>
	/// <returns></returns>
	protected virtual bool CheckIsPossibleSave(object? parametr)
	{
		return true;
	}

	/// <summary>
	/// Закрыть окно. (Метод который вызывается командой CloseWindowCommand)
	/// </summary>
	/// <param name="parametr"></param>
	protected void CloseWindow(object? parametr)
	{
		var view = parametr as IView;
		if (view != null) view.Close();
	}


	/// <summary>
	/// Проверка можно ли выполнять команду "Отмена/закрыть окно"
	/// </summary>
	/// <param name="parametr"></param>
	/// <returns></returns>
	private bool CheckIsPossibleCloseWindow(object? parametr)
	{
		return true;
	}

	//protected override void CheckCommands()
	//{
	//	SaveCommand?.RaiseCanExecuteChanged();
	//	CloseWindowCommand?.RaiseCanExecuteChanged();
	//}

	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string prop = "")
	{
		if (PropertyChanged != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(prop));
			CheckCommands();
		}
	}

	/// <summary>
	/// Проверка можно ли выполнить команды
	/// </summary>
	protected virtual void CheckCommands()
	{
		SaveCommand?.RaiseCanExecuteChanged();
		CloseWindowCommand?.RaiseCanExecuteChanged();
	}
}
