using EntitiesLibrary.Base;
using System.Data;
using System.Reflection;

namespace ViewModels.Base;

/// <summary>
/// Базовый класс для всех AddViewModel
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseAddEntityViewModel<TEntity>: INotifyPropertyChanged, IViewModelWithParametr, IDisposable
	where TEntity : class, INotifyPropertyChanged, new()
{
	public bool IsBusy { get; set; }

	public object? Parametr { set => OnParametrSet(value); }

	/// <summary>
	/// Главная сущность/объект
	/// </summary>
	public TEntity? MainEntity { get=> mainEntity; set { mainEntity = value; OnPropertyChanged(); } }
	private TEntity? mainEntity;

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
		MainEntity.PropertyChanged += OnMainEntityPropertiesChanged;

		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД

		//настраиваем команды
		SaveCommand = new RelayCommand(Save, CheckIsPossibleSave);
		CloseWindowCommand = new RelayCommand(CloseWindow, CheckIsPossibleCloseWindow);
	}

	public void Dispose()
	{
		if(MainEntity!=null)
			MainEntity.PropertyChanged -= OnMainEntityPropertiesChanged;
	}

	protected void OnMainEntityPropertiesChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(MainEntity));
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
			var view = serviceProvider.GetRequiredService<IMessageWindowView>();
			view.ViewModel.Parametr = "Ошибка при выполнении операции сохранения данных. Попробуйте выполнить операцию позже или обратитесь к администратору";
			view.ShowDialog();
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
		//Если объект не существуе, возвращаем false
		if (MainEntity == null) return false;
		
		//проверяем если есть ошибки валидации, тогда возвращаем false
		BaseINotifyDataErrorInfo? mainEntity = MainEntity as BaseINotifyDataErrorInfo;
		//mainEntity?.Validate();
		if (mainEntity!=null && (mainEntity.HasErrors==true /*|| mainEntity.IsNoChecks==true*/)) return false;


		if (BaseINotifyDataErrorInfo.HasErrorsOnlyInMyPublicProperties(mainEntity))
			return false;


		return true;
	}

	/*
	protected bool HasErrorValidateAllProperties(TEntity? entity)
	{
		if(entity==null) return false;

		Type type = entity.GetType();

		//DeclaredOnly: получает только методы непосредственно данного класса, унаследованные методы не извлекаются
		PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).ToArray();

		var properties2 = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.IgnoreCase | BindingFlags.Public).ToList();

		foreach (PropertyInfo property in properties)
		{
			
			//entity.Validate(property.Name);
			//if (entity.HasErrors) return true;

			//Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
		}
		return false;
	}
	*/

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
