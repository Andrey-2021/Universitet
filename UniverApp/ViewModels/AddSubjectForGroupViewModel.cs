namespace ViewModels;

/// <summary>
/// ViewModel для окна в котором выбираем Предмет, чтобы его добавить в Группу (В каждой Группе изучается/привязывается несколько Предметов )
/// </summary>
public class AddSubjectForGroupViewModel : BaseAddEntityViewModel<UniversitetGroup>, INotifyPropertyChanged
{
	/// <summary>
	/// Список изучаемых предметов
	/// </summary>
	public ObservableCollection<Subject>? Subjects{get => subjects;set{subjects = value;OnPropertyChanged(); } }
	public ObservableCollection<Subject>? subjects;

	/// <summary>
	/// Выбранный предмет
	/// </summary>
	public Subject? SelectedSubject
	{
		get => selectedSubject;
		set
		{
			selectedSubject = value;
			OnPropertyChanged();
		}
	}
	public Subject? selectedSubject;



	/// <summary>
	/// Констуктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddSubjectForGroupViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		//Task.Run(() => LoadSubjects());
	}

	/// <summary>
	/// Загрузка изучаемых предметов
	/// </summary>
	/// <returns></returns>
	protected override async Task OperationsAfterSetParametrAsync()
	{
		IsBusy = true;
		//читаем все Предметы из БД
		var response = await repository.GetEntitiesAsync<Subject>();
		if (response == null)
			Subjects = null;
		else
		{
			//удаляем предметы те, которые уже есть в группе
			if (MainEntity.Subjects != null)
			{
				foreach (var item in MainEntity.Subjects)
					response.RemoveAll(x=>x.Id==item.Id);
			}
			Subjects = new ObservableCollection<Subject>(response);
		}
		IsBusy = false;
	}

	protected override async void Save(object? parametr)
	{
		var result = await repository.SaveGroupAsync(MainEntity, SelectedSubject!);

		if (result != null) //если ошибка
		{
			//Message = "Ошибка";
			return;
		}

		//всё хорошо, закрываем  окно
		var view = parametr as IView;
		if (view != null) view.Close();
		

	}

	protected override bool CheckIsPossibleSave(object? parametr)
	{
		return SelectedSubject != null;
	}


	////Реализация интерфейса INotifyPropertyChanged
	//public event PropertyChangedEventHandler? PropertyChanged;
	//public void OnPropertyChanged([CallerMemberName] string prop = "")
	//{
	//	if (PropertyChanged != null)
	//	{
	//		PropertyChanged(this, new PropertyChangedEventArgs(prop));
	//		SaveCommand?.RaiseCanExecuteChanged();
	//	}
	//}

	protected override void CheckCommands()
	{
		SaveCommand?.RaiseCanExecuteChanged();
		base.CheckCommands();
	}
}
