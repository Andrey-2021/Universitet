using EntitiesLibrary.Interfaces;
namespace ViewModels.Base;

/// <summary>
/// Базовый класс для ViewModel-ей окон в которых выводятся все данные (обычно в таблицу)
/// </summary>
/// <typeparam name="TEntity">Тип главной сущности</typeparam>
/// <typeparam name="TAddView">Тип View (Окна) для добавления новой/редактирования сущности</typeparam>
public class BaseAllEntitiesViewModel<TEntity, TAddView>: INotifyPropertyChanged, IViewModel
	where TEntity : class, IHaveId, new()
	where TAddView : IViewWithViewModel
{
	public bool IsBusy { get; set; }
	protected IServiceProvider serviceProvider;
	protected DbRepository repository;

	public ObservableCollection<TEntity>? entities;
	
	/// <summary>
	/// Список сущностей из БД
	/// </summary>
	public ObservableCollection<TEntity>? Entities
	{
		get => entities;
		set
		{
			entities = value;
			OnPropertyChanged();
		}
	}

	public TEntity? selectedEntity;
	
	/// <summary>
	/// Выбранная сущность
	/// </summary>
	public TEntity? SelectedEntity
	{
		get => selectedEntity;
		set
		{
			selectedEntity = value;
			OnPropertyChanged();
		}
	}
	
	/// <summary>
	/// Команда "Добавить"
	/// </summary>
	public ICommand? AddCompanyCommand { private set; get; }

	/// <summary>
	/// Команда "Обновить"
	/// </summary>
	public ICommand? RefreshCommand { private set; get; }

	/// <summary>
	/// Команда "Удалить"
	/// </summary>
	public RelayCommand? DelCommand { private set; get; }

	/// <summary>
	/// Команда "Редактировать"
	/// </summary>
	public RelayCommand? EditCommand { private set; get; }

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public BaseAllEntitiesViewModel(IServiceProvider serviceProvider)
	{
		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>();
		
		//настраиваем команды
		AddCompanyCommand = new RelayCommand(ShowAddEntityWindow, CheckIsPossibleShowAddEntityWindow);
		RefreshCommand = new RelayCommand(RefreshEntities);
		DelCommand = new RelayCommand(DelEntity, CheckIsPossibleDeleAddEntity);
		EditCommand = new RelayCommand(EditEntity, CheckIsPossibleEditAddEntity);

		var task= Task.Run(() => LoadNecessaryDates());
		task.Wait();
	}

	protected virtual async void ShowAddEntityWindow(object? parametr)
	{
		var view = serviceProvider.GetRequiredService<TAddView>();
		view.ShowDialog();
		await LoadNecessaryDates();
	}

	protected virtual bool CheckIsPossibleShowAddEntityWindow(object? parametr)
	{
		return true;
	}

	protected virtual async void RefreshEntities(object? parametr)
	{
		await LoadNecessaryDates();
	}

	protected virtual async void DelEntity(object? parametr)
	{
		if (SelectedEntity == null) return;
		IsBusy = true;
		await repository.DelEntityAsync<TEntity>(SelectedEntity);
		await LoadNecessaryDates();
		IsBusy = false;
	}

	protected virtual bool CheckIsPossibleDeleAddEntity(object? parametr)
	{
		return SelectedEntity!=null;
	}

	protected virtual async void EditEntity(object? parametr)
	{
		var view = serviceProvider.GetRequiredService<TAddView>();
		view.ViewModel.Parametr = SelectedEntity;
		view.ShowDialog();
		await LoadNecessaryDates();
	}

	protected virtual bool CheckIsPossibleEditAddEntity(object? parametr)
	{
		return SelectedEntity != null;
	}

	/// <summary>
	/// Загрузка сущностей из БД
	/// </summary>
	/// <returns></returns>
	protected virtual async Task LoadNecessaryDates()
	{
		IsBusy = true;
		var response = await repository.GetEntitiesAsync<TEntity>();
		if (response == null)
			Entities = null;
		else
			Entities = new ObservableCollection<TEntity>(response);
		IsBusy = false;
	}



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
		DelCommand?.RaiseCanExecuteChanged();
		EditCommand?.RaiseCanExecuteChanged();
	}
}
