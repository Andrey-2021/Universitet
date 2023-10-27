namespace ViewModels;

public class AddAttendanceViewModel : BaseAddEntityViewModel<Attendance>
{
	/// <summary>
	/// Список Груп
	/// </summary>
	public ObservableCollection<UniversitetGroup>? UniversitetGroups { get => universitetGroups; set { universitetGroups = value; OnPropertyChanged(); } }
	public ObservableCollection<UniversitetGroup>? universitetGroups;

	/// <summary>
	/// Список Дат учёбы
	/// </summary>
	public ObservableCollection<LearningDate>? LearningDates { get => learningDates; set { learningDates = value; OnPropertyChanged(); } }
	public ObservableCollection<LearningDate>? learningDates;

	/// <summary>
	/// Выбранная группа
	/// </summary>
	public UniversitetGroup? SelectedGroup
	{
		get => selectedGroup;
		set
		{
			selectedGroup = value;
			SelectStudentsForTable();
			OnPropertyChanged();
		}
	}
	public UniversitetGroup? selectedGroup;

	
	/// <summary>
	/// Выбранная дата учёбы
	/// </summary>
	public LearningDate? SelectedLearningDate 
	{ 
		get => selectedLearningDate; 
		set 
		{ 
			selectedLearningDate = value;
			SelectStudentsForTable();
			OnPropertyChanged(); 
		} 
	}
	public LearningDate? selectedLearningDate;

	/// <summary>
	/// Список студентов
	/// </summary>
	public ObservableCollection<Attendance>? Attendances { get => attendances; set { attendances = value; OnPropertyChanged(); } }
	public ObservableCollection<Attendance>? attendances;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddAttendanceViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		//Task.Run(() => LoadNecessaryDates());
		LoadNecessaryDates();
	}


	private async void LoadNecessaryDates()
	{
		IsBusy = true;
		//читаем из БД
		var responseGroups = await repository.GetEntitiesAsync<UniversitetGroup>();
		var responseLearningDates = await repository.GetEntitiesAsync<LearningDate>();

		if (responseGroups == null) UniversitetGroups = null;
		else UniversitetGroups = new ObservableCollection<UniversitetGroup>(responseGroups);

		if (responseLearningDates == null) LearningDates = null;
		else LearningDates = new ObservableCollection<LearningDate>(responseLearningDates);
		IsBusy = false;
	}

	public async Task SelectStudentsForTable()
	{
		if (SelectedGroup == null || SelectedLearningDate == null)
		{
			//Attendances = null;
			return;
		}

		//Выбитраем всех студентов из выбранной группы
		var result = await repository.GetAttendanceAsync(SelectedGroup, SelectedLearningDate);
		
		if (result == null) Attendances = null;
		else Attendances = new ObservableCollection<Attendance>(result);
	}

	protected override async void Save(object? parametr)
	{
		var result = await repository.SaveAttendancesAsync(Attendances!.ToList());

		if (result != null) //если ошибка
		{
			//Message = "Ошибка";
			return;
		}
		CloseWindow(parametr);//всё хорошо, закрываем  окно
	}

	protected override bool CheckIsPossibleSave(object? parametr)
	{
		return Attendances?.Count > 0;
	}


	protected override void CheckCommands()
	{
		//SelectStudentsForTable();
		base.CheckCommands();
	//	SaveCommand?.RaiseCanExecuteChanged();
	//	CloseWindowCommand?.RaiseCanExecuteChanged();
	}

}
